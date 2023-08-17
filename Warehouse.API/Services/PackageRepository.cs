using Microsoft.EntityFrameworkCore;
using Warehouse.API.DbContexts;
using Warehouse.API.Entities;

namespace Warehouse.API.Services
{
    public class PackageRepository
    {
        private readonly WarehouseContext _context;
        public PackageRepository(WarehouseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Package>> GetPackagesByFilterAsync(string?filter)
        {
            var collection = _context.Packages
                as IQueryable<Package>;
             if (filter.Equals("outgoing"))
                collection = collection
                .Where(P => P.SchedulingProcess.ActualOutDate != null
                );
            else if (filter.Equals("current"))
                collection = collection
                .Where(P => P.SchedulingProcess.ActualOutDate == null
                && P.SchedulingProcess.ActualInDate != null);
            return await collection.Include(p => p.SchedulingProcess).ToListAsync();

        }
    }
}
