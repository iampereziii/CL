using AutoMapper;
using CL.Web.App_Start;

namespace CL.Service.Implementation
{
    public static class AutoMapperService
    {
        public static IMapper Mapper { get; set; }
        public static void Map() {
           
            Mapper = new MapperConfiguration(
                 config =>
                 {
                     config.AddProfile<MappingProfile>();
                 }).CreateMapper();
            
        }
    }
}
