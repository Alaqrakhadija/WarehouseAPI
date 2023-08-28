using AutoMapper;
using Warehouse.Application.Models;
using Warehouse.Domain.Entities;
namespace Warehouse.Application.Profiles
{
    public class LocationProfile:Profile
    {
        public LocationProfile() {
            CreateMap<Location, LocationDto>();
            CreateMap<LocationForCreateUpdateDto, Location>();
        }

    }
}
