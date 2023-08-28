
using AutoMapper;
using Warehouse.Application.Models;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Profiles
{
    public class ContainerProfile:Profile
    {
        public ContainerProfile() {
            CreateMap<Container, ContainerDto>();
            CreateMap<ContainerToCreateUpdateDto, Container>();
        }
    }
}
