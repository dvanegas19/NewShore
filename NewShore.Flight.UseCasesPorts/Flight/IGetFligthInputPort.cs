using NewShore.Flight.UsesCasesDTOs.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Flight.UseCasesPorts.Flight
{
    public interface IGetFligthInputPort
    {
        Task GetFlight(List<GetFlightParams> ListGetFlightParams);
    }
}
