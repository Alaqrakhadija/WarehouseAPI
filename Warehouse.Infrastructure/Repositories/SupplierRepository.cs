using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Entities;
using Warehouse.Domain.RepoInterfaces;
using Warehouse.Infrastructure.DbContexts;

namespace Warehouse.Infrastructure.Repositories
{
    public  class SupplierRepository: ISupplierRepository
    {
        private readonly WarehouseContext _context;
        private readonly ILogger<SupplierRepository> _logger;

        public SupplierRepository(WarehouseContext context, ILogger<SupplierRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }
        public async Task<Supplier> GetSupplierAsync(int id)
        {
           return await _context.Suppliers.FindAsync(id);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task PostSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task  PutSupplierAsync(Supplier supplier)
        {;
           _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public bool SupplierExists(int id)
        {
            return (_context.Suppliers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
