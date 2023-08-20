using AutoMapper;
using Warehouse.API.Entities;
using Warehouse.API.Models;

namespace Warehouse.API.Profiles
{
    public class PackageProfile : Profile
    {
        public PackageProfile() {
            CreateMap<IGrouping<Customer, Package>, PackageForGroupingDto>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Key))
            .ForMember(dest => dest.Packages, opt => opt.MapFrom(src => src.ToList()));
            CreateMap<Package, CustomerGroupPackageDto>();
            CreateMap<Entities.Package, Models.PackageForCustomerDto>();
            CreateMap<Entities.Package, Models.PackageDto>().ForMember(dest => dest.SchedulingProcess, opt => opt.MapFrom(src => src.SchedulingProcess));
        }
    }
}
