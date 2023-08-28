using AutoMapper;
using Warehouse.Application.Models;
using Warehouse.Domain.Entities;
namespace Warehouse.Application.Profiles
{
    public class SchedulingProfile : Profile
    {
        public SchedulingProfile() {
            CreateMap<SchedulingProcess, SchedulingForPackageDto>();
        }
        
    }
}
