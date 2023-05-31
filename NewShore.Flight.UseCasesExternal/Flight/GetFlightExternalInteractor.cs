using FluentValidation;
using Microsoft.Extensions.Logging;
using NewShore.Flight.UseCasesExternal.Common.Validators;
using NewShore.Flight.UseCasesPortsExternal.Flight;
using NewShore.Flight.UsesCasesDTOs.Flight;
using NewShore.Flight.UsesCasesExternalDTOs.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Flight.UseCasesExternal.Flight
{
    public  class GetFlightExternalInteractor: IGetFligthExternalInputPort
    {
        readonly IGetFligthExternalOutputPort GetFligthExternalOutputPort;
        readonly IEnumerable<IValidator<RequestFlightExternalParams>> Validators;
        readonly ILogger<GetFlightExternalInteractor> Logger;

        public GetFlightExternalInteractor(IGetFligthExternalOutputPort getFligthOutputPort, IEnumerable<IValidator<RequestFlightExternalParams>> validators, ILogger<GetFlightExternalInteractor> logger) =>
         (GetFligthExternalOutputPort, Validators, Logger)=(getFligthOutputPort, validators, logger);

        public async Task<GetJourneyExternalParams> GetDataFromNewShoreApiOnly(RequestFlightExternalParams RequestFlightExternalParams)
        {
            try
            {
                await Validator<RequestFlightExternalParams>.Validate(RequestFlightExternalParams, Validators);

                return await GetFligthExternalOutputPort.GetDataFromNewShoreApiOnly(RequestFlightExternalParams.Origin, RequestFlightExternalParams.Destination);
            }
            catch (Exception ex)
            {
                Logger.LogCritical("GetDataFromNewShoreApiOnly", ex);
                throw;
            }
        }

        public async Task<GetJourneyExternalParams> GetDataFromNewShoreApiMultipleAndReturn(string Origin, string Destination)
        {
            try
            {
                return await GetFligthExternalOutputPort.GetDataFromNewShoreApiMultipleAndReturn(Origin, Destination);
            }
            catch (Exception ex)
            {
                Logger.LogCritical("GetDataFromNewShoreApiOnly", ex);
                throw;
            }
        }

        public async Task<GetJourneyExternalParams> GetDataFromNewShoreApiMultiple(string Origin, string Destination)
        {
            try
            {
                return await GetFligthExternalOutputPort.GetDataFromNewShoreApiMultiple(Origin, Destination);
            }
            catch (Exception ex)
            {
                Logger.LogCritical("GetPermission", ex);
                throw;
            }
        }
    }
}
