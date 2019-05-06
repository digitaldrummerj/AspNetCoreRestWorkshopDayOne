using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWorkshop.Api
{
    public class HelloWorldRequest : IRequest<string>
    {
        public string Message { get; set; }
    }
}
