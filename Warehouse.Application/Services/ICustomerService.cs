

using Warehouse.Application.Models;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Services
{
    public interface ICustomerService
    {
        public Task<IEnumerable<PackageForCustomerDto>> GetCustomerPackagesAsync(int customerId);
        public Task<IEnumerable<User>> GetCustomersAsync();
        public Task<User> GetCustomerAsync(int id);
        public Task<User> AddCustomerAsync(UserDto customer);
        public Task PutCustomerAsync(int id, UserDto customer);
    }
}
