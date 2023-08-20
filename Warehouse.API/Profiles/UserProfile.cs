using AutoMapper;
using Warehouse.API.Entities;
using Warehouse.API.Models;

namespace Warehouse.API.Profiles
{
    public class UserProfile :Profile
    {
        public UserProfile() {
            CreateMap<Models.UserDto, Entities.Customer>();
            CreateMap<Models.UserDto, Entities.Supplier>();
            CreateMap<Entities.Customer,Models.UserDto>();
            CreateMap<Entities.Supplier,Models.UserDto>();
            CreateMap<Entities.Customer, Entities.User>();
            CreateMap<Entities.User, Entities.Customer>();
            CreateMap<Entities.Supplier, Entities.User>();
            CreateMap<Entities.User, Entities.Supplier>();
        }
    }
}
