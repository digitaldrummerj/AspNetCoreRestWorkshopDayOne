using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWorkshop.Api.Jobs.GetJobs
{
    public class GetJobsRequestHandler : ValidatedRequestHandler<GetJobsRequest, IEnumerable<GetJobsResponse>>
    {
        private readonly WorkshopDbContext _workshopDbContext;

        private readonly IMapper _mapper;

        public GetJobsRequestHandler(
            IEnumerable<IValidator<GetJobsRequest>> validators,
            WorkshopDbContext workshopDbContext,
            IMapper mapper)
            : base(validators)
        {
            _workshopDbContext = workshopDbContext ?? throw new ArgumentNullException(nameof(workshopDbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        protected override async Task<IEnumerable<GetJobsResponse>> OnHandle(GetJobsRequest message, CancellationToken cancellationToken)
        {
            return await _workshopDbContext.Jobs
                .ProjectTo<GetJobsResponse>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}