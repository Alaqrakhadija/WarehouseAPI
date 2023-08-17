using AutoMapper;

namespace Warehouse.API.Profiles
{
    public class SchedulingProfile : Profile
    {
        public SchedulingProfile() {
            CreateMap<Entities.SchedulingProcess, Models.SchedulingForPackageDto>();
        }
        
    }
}
