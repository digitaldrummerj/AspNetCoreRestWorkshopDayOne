using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace AspNetCoreWorkshop.Api
{
    public class HelloWorldRequestHandler : ValidatedRequestHandler<HelloWorldRequest, string>
    {
        public HelloWorldRequestHandler(IEnumerable<IValidator<HelloWorldRequest>> validators) : base(validators)
        {
        }

        protected override Task<string> OnHandle(HelloWorldRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Hello, " + request.Message);
        }
    }
}
