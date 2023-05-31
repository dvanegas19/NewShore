using NewShore.Flight.UseCasesPorts.Flight;
using NewShore.Flight.UsesCasesDTOs.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Fligth.Presenters
{
    public class FlightPresenter : IGetFligthOutputPort, IPresenter<object>
    {

        public object content { get; private set; }

        public Task GetFlight(List<GetFlightParams> ListGetFlightParams)
        {
            content = ListGetFlightParams;
            return Task.CompletedTask;
        }

    }
}
