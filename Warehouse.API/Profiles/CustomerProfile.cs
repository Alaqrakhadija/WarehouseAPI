using AutoMapper;
using Warehouse.API.Entities;
using Warehouse.API.Models;

namespace Warehouse.API.Profiles
{
    public class CustomerProfile :Profile
    {
        public CustomerProfile() {
            CreateMap<Entities.Customer, Entities.User>();
        }
    }
}
