using AutoMapper;

namespace Warehouse.API.Profiles
{
    public class PackageProfile : Profile
    {
        public PackageProfile() {
            CreateMap<Entities.Package, Models.PackageForCustomerDto>();
            CreateMap<Entities.Package, Models.PackageDto>().ForMember(dest => dest.SchedulingProcess, opt => opt.MapFrom(src => src.SchedulingProcess)); 
        }
    }
}
