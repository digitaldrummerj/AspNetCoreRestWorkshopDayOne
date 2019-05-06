using MediatR;
using System.Collections.Generic;

namespace AspNetCoreWorkshop.Api.Jobs
{
    public class GetJobsRequest : IRequest<IEnumerable<GetJobsResponse>>
    {
    }
}
