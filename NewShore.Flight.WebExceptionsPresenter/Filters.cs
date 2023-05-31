using Microsoft.AspNetCore.Mvc;
using NewShore.Fligth.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace NewShore.Fligth.WebExceptionsPresenter
{
    public static class Filters
    {
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(new ApiExceptionFilterAttribute(new Dictionary<Type, IExceptionHandler> {
                { typeof(GeneralException), new GeneralExceptionHandler() },
                { typeof(ValidationException), new ValidationExceptionHandler()}
            }));
        }
    }
}
