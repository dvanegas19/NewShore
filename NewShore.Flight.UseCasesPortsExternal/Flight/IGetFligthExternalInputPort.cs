using NewShore.Flight.UsesCasesExternalDTOs.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Flight.UseCasesPortsExternal.Flight
{
    public interface IGetFligthExternalInputPort
    {
        Task<GetJourneyExternalParams> GetDataFromNewShoreApiOnly(RequestFlightExternalParams RequestFlightExternalParams);

        Task<GetJourneyExternalParams> GetDataFromNewShoreApiMultiple(string Origin, string Destination);

        Task<GetJourneyExternalParams> GetDataFromNewShoreApiMultipleAndReturn(string Origin, string Destination);

        
    }
}
