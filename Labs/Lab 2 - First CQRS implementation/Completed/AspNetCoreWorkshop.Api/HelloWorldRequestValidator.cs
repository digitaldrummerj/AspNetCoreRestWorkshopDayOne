using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWorkshop.Api
{
    public class HelloWorldRequestValidator : AbstractValidator<HelloWorldRequest>
    {
        public HelloWorldRequestValidator()
        {
            RuleFor(r => r.Message).NotEmpty().WithMessage("Please enter a message");
        }
    }
}
