

using Warehouse.Domain.Entities;

namespace Warehouse.Domain.RepoInterfaces
{
    public interface ICustomerRepository
    {
        public  Task<IEnumerable<Package>> GetCustomerPackagesAsync(int customerId);
        public  Task<IEnumerable<Customer>> GetCustomersAsync();
        public Task<Customer> GetCustomerAsync(int id);
        public  Task AddCustomerAsync(Customer customer);
        public Task UpdateCustomerAsync(Customer customer);
        public bool CustomerExists(int id);

    }
}
