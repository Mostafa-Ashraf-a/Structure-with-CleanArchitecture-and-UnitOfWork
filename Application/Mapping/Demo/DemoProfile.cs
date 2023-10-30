using MostafaProject.Domain.Dtos.Demo;

namespace MostafaProject.Application.Mapping.Demo
{
    public class DemoProfile : MappingProfileBase
    {
        public DemoProfile()
        {
            CreateMap<AddDemoDto, MostafaProject.Domain.Entities.Demo>()
                .ForMember(a => a.Created_by, d => d.MapFrom(a => a.Created_by));
                
        }
    }
}
