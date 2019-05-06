using AspNetCoreWorkshop.Api.Jobs;
using AspNetCoreWorkshop.Api.Jobs.GetJob;
using AspNetCoreWorkshop.Api.Jobs.GetJobs;
using AutoMapper;

namespace AspNetCoreWorkshop.Api
{
    public static class WorkshopMapper
    {
        public static IMapper CreateMapper()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Job, GetJobsResponse>();
                config.CreateMap<Job, GetJobResponse>();
            }).CreateMapper();
        }
    }
}