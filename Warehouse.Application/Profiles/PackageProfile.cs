using AutoMapper;

using Warehouse.Application.Models;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Profiles
{
    public class PackageProfile : Profile
    {
        public PackageProfile() {
            CreateMap<IGrouping<Customer,Package>, PackageForGroupingDto>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Key))
            .ForMember(dest => dest.Packages, opt => opt.MapFrom(src => src.ToList()));
            CreateMap<Package, CustomerGroupPackageDto>();
            CreateMap<Package, PackageForCustomerDto>();
            CreateMap<Package, PackageDto>().ForMember(dest => dest.SchedulingProcess, opt => opt.MapFrom(src => src.SchedulingProcess));
        }
    }
}
