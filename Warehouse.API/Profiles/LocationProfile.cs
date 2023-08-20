using AutoMapper;

namespace Warehouse.API.Profiles
{
    public class LocationProfile:Profile
    {
        public LocationProfile() {
            CreateMap<Entities.Location, Models.LocationDto>();
        }

    }
}
