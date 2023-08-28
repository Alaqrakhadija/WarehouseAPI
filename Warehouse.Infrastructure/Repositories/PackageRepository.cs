using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Warehouse.Infrastructure.DbContexts;
using Warehouse.Domain.Entities;
using Warehouse.Domain.RepoInterfaces;

namespace Warehouse.Infrastructure.Repositories
{
    public class PackageRepository: IPackageRepository
    {
        private readonly WarehouseContext _context;
        private readonly ILogger<PackageRepository> _logger;

        public PackageRepository(WarehouseContext context, ILogger<PackageRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException();
        }
        public async Task<IEnumerable<Package>> GetPackagesByFilterAsync(string filter)
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
        public async Task<Package> GetPackageAsync(int id)
        {
            
            return await _context.Packages.Include(p => p.SchedulingProcess).SingleOrDefaultAsync(p=>p.Id==id);

        }

        public async Task<IEnumerable<IGrouping<Customer, Package>>> GetPackagesByPeriodAsync(DateTime start, DateTime end)
        {




            return await _context.Packages.Where(p => _context.Set<SchedulingProcess>()
          .Where(

              s => (
              ((s.ActualOutDate == null ? s.ExpectedOutDate : s.ActualOutDate.Value).Date >= start.Date 
              && (s.ActualOutDate == null ? s.ExpectedOutDate : s.ActualOutDate.Value).Date <= end.Date) ||
             ((s.ActualInDate == null ? s.ExpectedInDate : s.ActualInDate.Value).Date >= start.Date 
             && (s.ActualInDate == null ? s.ExpectedInDate : s.ActualInDate.Value).Date <= end.Date)
              )


          ).Select(s => s.PackageId).Contains(p.Id)).Include(p => p.SchedulingProcess).GroupBy(p => p.Customer).ToListAsync();
            //return await _context.Packages.Where(p => _context.Set<SchedulingProcess>()
            //.Where(

            //    s=> (
            //    (s.ActualOutDate !=null&& (s.ActualOutDate.Value.Date >= start.Date && s.ActualOutDate.Value.Date <= end.Date) )||
            //   (s.ActualInDate != null && (s.ActualInDate.Value.Date >= start.Date && s.ActualInDate.Value.Date <= end.Date))
            //    ) 


            //).Select(s=>s.PackageId).Contains(p.Id)).Include(p => p.SchedulingProcess).GroupBy(p => p.Customer).ToListAsync();

        }
        public async Task<IEnumerable<IGrouping<Customer, Package>>> GetPackagesGroupByCustomerAsync()
        {
            return await _context.Packages.Include(p => p.SchedulingProcess).GroupBy(p => p.Customer).ToListAsync();

        }
        public async Task DeletePackagesAsync()
        {
            DateTime now = DateTime.Now;
            var packages = await _context.Packages
    .FromSqlRaw(@"
                SELECT p.*
                FROM Packages p
                LEFT JOIN SchedulingProcess sp ON p.Id = sp.packageId
                WHERE  
                    (sp.ActualInDate IS NULL AND DATEDIFF(day, sp.ExpectedInDate,GETDATE()) >= 3) OR
                    (sp.ActualInDate IS NOT NULL AND DATEDIFF(day,  sp.ExpectedInDate,sp.ActualInDate) >= 3)
            ")
    .Include(p => p.SchedulingProcess)
    .ToListAsync();
            _context.Packages.RemoveRange(packages);
            await _context.SaveChangesAsync();
            //var packages = await _context.Packages.Where(
            //    p => (p.SchedulingProcess.ActualInDate == null && (now.Date - p.SchedulingProcess.ExpectedInDate.Date).Days >= 3)
            //    || (p.SchedulingProcess.ActualInDate != null && (p.SchedulingProcess.ActualInDate.Value.Date - p.SchedulingProcess.ExpectedInDate.Date).Days >= 3)
            //    ).Include(p => p.SchedulingProcess).ToListAsync();



            //var packages =await _context.Packages.Where(
            //    p => (p.SchedulingProcess.ActualInDate == null && DateTime.Now.Day-p.SchedulingProcess.ExpectedInDate.Day >=3 )
            //    || (p.SchedulingProcess.ActualInDate != null && p.SchedulingProcess.ActualInDate.Value.Day- p.SchedulingProcess.ExpectedInDate.Day >= 3)
            //    ).Include(p=>p.SchedulingProcess).ToListAsync();


        }

        public async Task AddPackageAsync(Package package)
        {
            
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();

        }
        public async Task UpdatePackageAsync(Package package)
        {

            _context.Entry(package).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public bool PackageExists(int id)
        {
            return (_context.Packages?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
