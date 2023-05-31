using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Fligth.WebExceptionsPresenter
{
    public class ExceptionHandlerBase
    {
        readonly Dictionary<int, string> RFC271 = new Dictionary<int, string>
        {
            {
                StatusCodes.Status500InternalServerError,
                "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
            },
             {
                StatusCodes.Status400BadRequest,
                "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4"
            }

        };

        public Task SetResult(ExceptionContext context, int? status, string title, string detail)
        {
            ProblemDetails Details = new ProblemDetails
            {
                Status = status,
                Title = title,
                Type = RFC271.ContainsKey(status.Value) ? RFC271[status.Value] : "",
                Detail = detail
            };

            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
