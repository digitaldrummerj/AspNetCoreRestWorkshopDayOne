using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AspNetCoreWorkshop.Api.Jobs
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : WorkshopController
    {
        public JobsController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet]
        public Task<IActionResult> GetJobs()
        {
            return HandleRequestAsync(new GetJobsRequest());
        }
    }
}

