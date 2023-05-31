using Microsoft.AspNetCore.Mvc;
using NewShore.Flight.UsesCasesDTOs;
using NewShore.Flight.UseCases;
using NewShore.Flight.UsesCasesDTOs.Flight;
using NewShore.Flight.UseCasesPorts.Flight;
using NewShore.Fligth.Presenters;

namespace NewShore.Flight.WebApi.Controllers
{
    [Route("[api/controller]")]
    [ApiController]    
    public class FligthController : ControllerBase
    {

        readonly IGetFligthInputPort GetFligthInputPort;
        readonly IGetFligthOutputPort GetFligthOutputPort;

        public FligthController(IGetFligthInputPort getFligthInputPort, IGetFligthOutputPort getFligthOutputPort)
        {
            GetFligthInputPort = getFligthInputPort;
            GetFligthOutputPort = getFligthOutputPort;
        }

        [HttpGet(Name = "GetFligth")]
        // GET: FligthController/Details/5
        public async Task<ActionResult<object>> GetFligth(RequestFlightParams RequestFlightParams)
        {

            // Validar parametros RequestFlightParams

            List<GetFlightParams> ListFlightParams = new List<GetFlightParams>();

            await GetFligthInputPort.GetFlight(ListFlightParams);
            var Presenter = GetFligthOutputPort as FlightPresenter;
            return Presenter.content;

        }



    }
}
