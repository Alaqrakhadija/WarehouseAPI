using AutoMapper;
using Warehouse.Domain.Entities;
using Warehouse.Application.Models;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Profiles
{
    public class UserProfile :Profile
    {
        public UserProfile() {
            CreateMap<UserDto, Customer>();
            CreateMap<UserDto,Supplier>();
            CreateMap<Customer,UserDto>();
            CreateMap<Supplier,UserDto>();
            CreateMap<Customer, User>();
            CreateMap<User, Customer>();
            CreateMap<Supplier, User>();
            CreateMap<User, Supplier>();
        }
    }
}
