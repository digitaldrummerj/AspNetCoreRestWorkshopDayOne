using System.Collections.Generic;
using MediatR;

namespace AspNetCoreWorkshop.Api.Jobs.GetJobs
{
    public class GetJobsRequest : IRequest<IEnumerable<GetJobsResponse>>
    {
    }
}
