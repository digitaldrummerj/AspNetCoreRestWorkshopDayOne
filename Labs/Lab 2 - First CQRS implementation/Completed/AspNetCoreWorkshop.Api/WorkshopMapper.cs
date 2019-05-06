using AutoMapper;

namespace AspNetCoreWorkshop.Api
{
    public static class WorkshopMapper
    {
        public static IMapper CreateMapper()
        {
            return new MapperConfiguration(config =>
            {
                
            }).CreateMapper();
        }
    }
}