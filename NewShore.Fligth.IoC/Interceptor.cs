using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NewShore.Flight.UseCasesPorts.Flight;
using NewShore.Fligth.Presenters;
using NewShore.Flight.UseCases.Common.Validators;
using Microsoft.Extensions.Configuration;
using NewShore.Flight.UseCases.Flight;
using NewShore.Flight.UseCasesPortsExternal.Flight;
using NewShore.Flight.UseCasesExternal.Flight;
using NewShore.Flight.UsesCasesExternalDTOs.Flight;

namespace NewShore.Fligth.IoC
{
    public static class Interceptor
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddValidatorsFromAssembly(typeof(RequestFlightExternalParams).Assembly);
            services.AddScoped<IGetFligthOutputPort, FlightPresenter>();
            services.AddScoped<IGetFligthInputPort, GetFlightInteractor>();
            services.AddScoped<IGetFligthExternalInputPort, GetFlightExternalInteractor>();
            services.AddScoped<IGetFligthExternalOutputPort, FlightExternalPresenter>();


            return services;
        }
    }
}
