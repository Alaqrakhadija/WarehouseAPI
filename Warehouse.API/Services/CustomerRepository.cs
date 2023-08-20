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
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers
                .ToListAsync();
        }
        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _context.Customers
                .SingleOrDefaultAsync(c=>c.Id==id);
        }
        public async Task AddCustomerAsync(Customer customer)
        {
           _context.Customers
                .Add(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
 

        public bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
