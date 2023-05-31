using Microsoft.Extensions.Logging;
using NewShore.Flight.UseCasesExternal.Flight;
using NewShore.Flight.UseCasesPortsExternal.Flight;
using NewShore.Flight.UsesCasesExternalDTOs.Flight;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NewShore.Fligth.Presenters
{
    public class FlightExternalPresenter : IGetFligthExternalOutputPort, IPresenter<object>
    {
        readonly HttpClient _httpClient = new HttpClient();
        public object content { get; private set; }
        public List<FligthExternalParams> NewFlights = new List<FligthExternalParams>();
        public List<FligthExternalParams> Flights = new List<FligthExternalParams>();
        public GetJourneyExternalParams Response = new GetJourneyExternalParams();

        public List<GetFlightExternalParams> ListGetFlightExternalParams = new List<GetFlightExternalParams>();

        readonly ILogger<GetFlightExternalInteractor> Logger;

        private Dictionary<string, List<FligthExternalParams>> adjacencyList = new Dictionary<string, List<FligthExternalParams>>();

        #region one case

        public async Task<GetJourneyExternalParams> GetDataFromNewShoreApiOnly(string Origin, string Destination)
        {
            var response = await _httpClient.GetAsync("https://recruiting-api.newshore.es/api/flights/0");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    Flights = await JsonSerializer.DeserializeAsync<List<FligthExternalParams>>(stream);

                    NewFlights = this.FindRoutesOnly(Origin, Destination);

                }
            }
            else
            {
                Logger.LogError("GetDataFromNewShoreApiOnly", response.StatusCode);
            }
            return ConvertModelJourney(NewFlights) ;
        }

        private GetJourneyExternalParams ConvertModelJourney(List<FligthExternalParams> ConvertModel)
        {
            if(NewFlights.Count()> 0)
            {
                NewFlights.ForEach(record =>
                {
                    ListGetFlightExternalParams.Add(new GetFlightExternalParams
                    {
                        Origin = record.departureStation,
                        Destination = record.arrivalStation,
                        Price = record.price,
                        Transport = new GetTransportParams { FlightCarrier = record.flightCarrier, FlightNumber = record.flightNumber }
                    });

                });

                Response.Origin = ListGetFlightExternalParams.First().Origin;
                Response.Destination = ListGetFlightExternalParams.Last().Destination;
                Response.Price = ListGetFlightExternalParams.Sum(price => price.Price);
                Response.Flights = ListGetFlightExternalParams;

                return Response;

            }
            else
            {
                return new GetJourneyExternalParams();
            }          
        }

        public List<FligthExternalParams> FindRoutesOnly(string Origin, string Destination)
        {
            List<FligthExternalParams> routes = new List<FligthExternalParams>();

            foreach (var route in Flights)
            {
                if (route.departureStation == Origin && route.arrivalStation == Destination)
                {
                    routes.Add(route);
                }               
            }   
            return routes;
        }

        #endregion

        #region two case
        public async Task<GetJourneyExternalParams> GetDataFromNewShoreApiMultiple(string Origin, string Destination)
        {
            var response = await _httpClient.GetAsync("https://recruiting-api.newshore.es/api/flights/1");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    Flights = await JsonSerializer.DeserializeAsync<List<FligthExternalParams>>(stream);

                    NewFlights = this.FindRoutes(Origin, Destination);
                }
            }
            else
            {
                Logger.LogError("GetDataFromNewShoreApiOnly", response.StatusCode);
            }


            return ConvertModelJourney(NewFlights) ; 
        }

        public List<FligthExternalParams> FindRoutes(string Origin, string Destination)
        {
            List<FligthExternalParams> routes = new List<FligthExternalParams>();

            foreach (var route in Flights)
            {
                if (route.departureStation == Origin && route.arrivalStation == Destination)
                {
                    routes.Add(route);
                }
                else if (route.departureStation == Origin)
                {
                    List<FligthExternalParams> intermediateRoutes = FindRoutes(route.arrivalStation, Destination);
                    if (intermediateRoutes.Count > 0)
                    {
                        routes.Add(route);
                        routes.AddRange(intermediateRoutes);
                    }
                }
            }

            return routes;
        }
        #endregion


        #region three case

        public async Task<GetJourneyExternalParams> GetDataFromNewShoreApiMultipleAndReturn(string Origin, string Destination)
        {
            var response = await _httpClient.GetAsync("https://recruiting-api.newshore.es/api/flights/2");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    Flights = await JsonSerializer.DeserializeAsync<List<FligthExternalParams>>(stream);
                }
            }
            else
            {
                Logger.LogError("GetDataFromNewShoreApiOnly", response.StatusCode);
            }
            List<FligthExternalParams> routes = await FindRoutesMultiple(Origin, Destination);


            return ConvertModelJourney(NewFlights); 
        }

        public async Task<List<FligthExternalParams>> FindRoutesMultiple(string departureStation, string arrivalStation)
        {
            List<FligthExternalParams> routes = Flights;
            List<FligthExternalParams> directRoutes = FindDirectRoutes(routes, departureStation, arrivalStation);
            List<FligthExternalParams> routesWithStops = FindRoutesWithStops(routes, departureStation, arrivalStation);
            List<FligthExternalParams> allRoutes = new List<FligthExternalParams>();
            allRoutes.AddRange(directRoutes);
            allRoutes.AddRange(routesWithStops);

            return allRoutes;
        }

        private List<FligthExternalParams> FindDirectRoutes(List<FligthExternalParams> routes, string departureStation, string arrivalStation)
        {
            List<FligthExternalParams> directRoutes = new List<FligthExternalParams>();

            foreach (FligthExternalParams route in routes)
            {
                if (route.departureStation == departureStation && route.arrivalStation == arrivalStation)
                {
                    directRoutes.Add(route);
                }
            }

            return directRoutes;
        }

        private List<FligthExternalParams> FindRoutesWithStops(List<FligthExternalParams> routes, string departureStation, string arrivalStation)
        {
            List<FligthExternalParams> routesWithStops = new List<FligthExternalParams>();

            foreach (FligthExternalParams route in routes)
            {
                if (route.departureStation == departureStation)
                {
                    // Encontrar rutas con escalas desde la estación de salida
                    List<FligthExternalParams> intermediateStations = FindIntermediateStations(routes, route.arrivalStation, arrivalStation, new HashSet<string>());
                    if (intermediateStations.Count > 0)
                    {
                        string routeInfo = $"Ruta con escalas: {route.departureStation} -> {string.Join(" -> ", intermediateStations)} -> {arrivalStation}, Precio: {route.price}";
                        routesWithStops.Add(route);
                    }
                }
            }
            return routesWithStops;
        }

        private List<FligthExternalParams> FindIntermediateStations(List<FligthExternalParams> routes, string currentStation, string finalStation, HashSet<string> visitedStations)
        {
            List<FligthExternalParams> intermediateStations = new List<FligthExternalParams>();

            if (currentStation == finalStation )
            {
                return intermediateStations;
            }

            visitedStations.Add(currentStation);

            foreach (FligthExternalParams route in routes)
            {
                if (route.departureStation == currentStation && !visitedStations.Contains(route.arrivalStation))
                {
                    // Encontrar estaciones intermedias recursivamente
                    List<FligthExternalParams> nextStations = FindIntermediateStations(routes, route.arrivalStation, finalStation, visitedStations);
                    if (nextStations.Count > 0 || route.arrivalStation == finalStation)
                    {
                        intermediateStations.Insert(0, route);
                        intermediateStations.InsertRange(0, nextStations);
                        break;
                    }
                }
            }

            visitedStations.Remove(currentStation);

            return intermediateStations;
        }

        #endregion

    }
}
