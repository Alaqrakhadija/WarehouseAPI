
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Models;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Services
{
    public interface ISupplierService
    {
        public Task<IEnumerable<User>> GetSuppliers();
        public Task<User> GetSupplier(int id);
        public Task PutSupplier(int id, UserDto supplier);
        public Task<User> PostSupplier(UserDto supplier);
    }
}
