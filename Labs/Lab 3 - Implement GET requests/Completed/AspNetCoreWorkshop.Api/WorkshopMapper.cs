using AspNetCoreWorkshop.Api.Jobs;
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
            }).CreateMapper();
        }
    }
}