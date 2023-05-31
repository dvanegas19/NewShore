using Microsoft.AspNetCore.Mvc;
using NewShore.Flight.UsesCasesDTOs;
using NewShore.Flight.UseCases;
using NewShore.Flight.UsesCasesDTOs.Flight;
using NewShore.Flight.UseCasesPorts.Flight;
using NewShore.Fligth.Presenters;
using NewShore.Flight.UseCasesPortsExternal.Flight;
using NewShore.Flight.UsesCasesExternalDTOs.Flight;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace NewShore.Flight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FligthController 
    {

        readonly IGetFligthInputPort GetFligthInputPort;
        readonly IGetFligthOutputPort GetFligthOutputPort;
        readonly IGetFligthExternalInputPort GetFligthExternalInputPort;
        readonly IGetFligthExternalOutputPort GetFligthExternalOutputPort;


        //readonly FlightExternalPresenter FlightExternalPresenter;

        public FligthController(IGetFligthInputPort getFligthInputPort, IGetFligthOutputPort getFligthOutputPort, IGetFligthExternalInputPort getFligthExternalInputPort, IGetFligthExternalOutputPort getFligthExternalOutputPort )
        {
            GetFligthInputPort = getFligthInputPort;
            GetFligthOutputPort = getFligthOutputPort;
            GetFligthExternalInputPort = getFligthExternalInputPort;
            GetFligthExternalOutputPort = getFligthExternalOutputPort;
        }

        [HttpGet("GetDataFromNewShoreApiOnly")]
        // GET: GetDataFromNewShoreApiOnly/RequestFlightParams
        public async Task<ActionResult<object>> GetDataFromNewShoreApiOnly([FromQuery] RequestFlightExternalParams RequestFlightParams)
        {

            List<GetFlightsExternalParams> ListFlightExternalParams = new List<GetFlightsExternalParams>();
            List<GetFlightParams> ListFlightParams = new List<GetFlightParams>();
            var response = GetFligthExternalInputPort.GetDataFromNewShoreApiOnly(RequestFlightParams);
            return response.Result;

        }

        [HttpGet("GetFligthMultiple")]
        // GET: GetFligthMultiple/RequestFlightParams
        public async Task<ActionResult<object>> GetFligthMultiple([FromQuery] RequestFlightParams RequestFlightParams)
        {

            List<GetFlightsExternalParams> ListFlightExternalParams = new List<GetFlightsExternalParams>();
            List<GetFlightParams> ListFlightParams = new List<GetFlightParams>();
            var response = GetFligthExternalInputPort.GetDataFromNewShoreApiMultiple(RequestFlightParams.Origin, RequestFlightParams.Destination);
            return response.Result;

        }

        [HttpGet("GetFligthMultipleAndReturn")]
        // GET: GetFligthMultipleAndReturn/RequestFlightParams
        public async Task<ActionResult<object>> GetFligthMultipleAndReturn([FromQuery] RequestFlightParams RequestFlightParams)
        {

            List<GetFlightsExternalParams> ListFlightExternalParams = new List<GetFlightsExternalParams>();
            List<GetFlightParams> ListFlightParams = new List<GetFlightParams>();
            var response = GetFligthExternalInputPort.GetDataFromNewShoreApiMultipleAndReturn(RequestFlightParams.Origin, RequestFlightParams.Destination);
            return  response.Result;

        }

        



    }
}
