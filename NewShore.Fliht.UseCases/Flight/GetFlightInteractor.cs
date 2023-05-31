using FluentValidation;
using Microsoft.Extensions.Logging;
using NewShore.Flight.UseCasesPorts.Flight;
using NewShore.Flight.UsesCasesDTOs.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Flight.UseCases.Flight
{
    public  class GetFlightInteractor: IGetFligthInputPort
    {
        readonly IGetFligthOutputPort GetFligthOutputPort;
        readonly IEnumerable<IValidator<GetFlightParams>> Validators;
        readonly ILogger<GetFlightInteractor> Logger;

        public GetFlightInteractor(IGetFligthOutputPort getFligthOutputPort, IEnumerable<IValidator<GetFlightParams>> validators, ILogger<GetFlightInteractor> logger) =>
         (GetFligthOutputPort, Validators, Logger)=(getFligthOutputPort, validators, logger);

        public async Task GetFlight(List<GetFlightParams> ListGetFlightParams)
        {
            try
            {
                List<GetFlightParams> test = new List<GetFlightParams>();

                test = ListGetFlightParams;
                await GetFligthOutputPort.GetFlight(test);
            }
            catch (Exception ex)
            {
                Logger.LogCritical("GetPermission", ex);
                throw;
            }

        }
    }
}
