using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using NewShore.Fligth.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Fligth.WebExceptionsPresenter
{
    public class GeneralExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var Exception = context.Exception as GeneralException;
            return SetResult(context, StatusCodes.Status500InternalServerError, Exception.Message, Exception.Detail);
        }
    }
}
