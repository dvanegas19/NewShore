using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Fligth.WebExceptionsPresenter
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        readonly IDictionary<Type, IExceptionHandler> ExceptionHandler;

        public ApiExceptionFilterAttribute(
            IDictionary<Type, IExceptionHandler> exceptionHandler
            ) => ExceptionHandler = exceptionHandler;

        public override void OnException(ExceptionContext context)
        {
            Type ExceptionType = context.Exception.GetType();
            if (ExceptionHandler.ContainsKey(ExceptionType))
            {
                ExceptionHandler[ExceptionType].Handle(context);
            }
            else
            {
                new ExceptionHandlerBase().SetResult(
                    context, StatusCodes.Status500InternalServerError,"Ocurrio un error al procesar la respuesta", ""
                    );
            }

            base.OnException(context);
        }

    }
}
