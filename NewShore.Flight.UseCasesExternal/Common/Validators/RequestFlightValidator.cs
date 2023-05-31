using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NewShore.Flight.UsesCasesDTOs.Flight;
using NewShore.Flight.UsesCasesExternalDTOs.Flight;

namespace NewShore.Flight.UseCasesExternal.Common.Validators
{
    public class RequestFlightValidator : AbstractValidator<RequestFlightExternalParams>
    {
        public RequestFlightValidator() {

            RuleFor(c => c.Origin).NotEmpty()
            .WithMessage("Debe indicar un origen.").MaximumLength(3).
            WithMessage("Debe contener maximo 3 caracteres");
            RuleFor(c => c.Destination).NotEmpty()
            .WithMessage("Debe indicar un destino.").MaximumLength(3).
            WithMessage("Debe contener maximo 3 caracteres"); 
        }
    }
}
