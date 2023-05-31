using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Fligth.WebExceptionsPresenter
{
    public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {    

        public Task Handle(ExceptionContext context)
        {
            var Exception = context.Exception as ValidationException;

            StringBuilder Builder = new StringBuilder();
            foreach(var Failure in Exception.ValidationResult.ErrorMessage)
            {
                Builder.AppendLine(string.Format("Propiedad: {0}. Error: {1}", "", Exception.ValidationResult.ErrorMessage));
            }
            return SetResult(context, StatusCodes.Status400BadRequest, "Error en los datos de entrada", Builder.ToString());

        }
    }
}
