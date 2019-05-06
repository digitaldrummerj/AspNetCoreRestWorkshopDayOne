using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWorkshop.Api.Jobs
{
    public class GetJobsRequestHandler : ValidatedRequestHandler<GetJobsRequest, IEnumerable<GetJobsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly WorkshopDbContext _workshopDbContext;

        public GetJobsRequestHandler(IEnumerable<IValidator<GetJobsRequest>> validators, IMapper mapper, WorkshopDbContext workshopDbContext) : base(validators)
        {
            this._mapper = mapper;
            this._workshopDbContext = workshopDbContext;
        }

        protected override async Task<IEnumerable<GetJobsResponse>> OnHandleAsync(GetJobsRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Job> jobs = _workshopDbContext.Jobs;

            return await jobs.ProjectTo<GetJobsResponse>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}
