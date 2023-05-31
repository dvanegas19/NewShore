using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Flight.UsesCasesExternalDTOs.Flight
{
    public class GetFlightExternalParams
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public double Price { get; set; }

        public GetTransportParams Transport { get; set; }
    }

    public class GetTransportParams
    {
        public string FlightCarrier { get; set;}

        public string FlightNumber { get; set;}
    }
}
