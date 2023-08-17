using Microsoft.EntityFrameworkCore;
using Warehouse.API.Controllers;
using Warehouse.API.DbContexts;
using Warehouse.API.Entities;

namespace Warehouse.API.Services
{
    public class CustomerRepository
    {
        private readonly WarehouseContext _context;
        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(WarehouseContext context,
            ILogger<CustomerRepository> logger)
        {
            _logger = logger;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Package>> GetCustomerPackagesAsync(int customerId)
        {

            return await _context.Packages
                .Where(p => p.CustomerId == customerId)
                .ToListAsync();

        }
        public async Task<bool> IsExist(int customerId)
        {

            return await _context.Customers.AnyAsync(c=>c.Id==customerId);

        }
    }
}
