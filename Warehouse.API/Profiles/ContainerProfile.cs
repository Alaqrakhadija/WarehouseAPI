using AutoMapper;

namespace Warehouse.API.Profiles
{
    public class ContainerProfile:Profile
    {
        public ContainerProfile() {
            CreateMap<Entities.Container, Models.ContainerDto>();
            CreateMap<Models.ContainerToCreateUpdateDto, Entities.Container>();
        }
    }
}
