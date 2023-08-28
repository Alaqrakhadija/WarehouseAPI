using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Warehouse.Infrastructure.DbContexts;
using Warehouse.Domain.Entities;
using Warehouse.Domain.RepoInterfaces;

namespace Warehouse.Infrastructure.Repositories
{
    public class LocationRepository: ILocationRepository
    {
        private readonly WarehouseContext _context;
        private readonly ILogger<LocationRepository> _logger;

        public LocationRepository(WarehouseContext context, ILogger<LocationRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException( nameof(logger));

        }
        public async Task<IEnumerable<Location>> GetFreeLocationsByDateAsync(DateTime filter)
        {

            var collection = _context.Locations.Where(l => l.Schedulings.Count == 0 ||
               !l.Schedulings.Any(s => s.ActualOutDate == null &&

               ((s.ActualInDate != null && (filter.Date>=s.ActualInDate.Value.Date && filter.Date <= s.ExpectedOutDate.Date)) ||
                (s.ActualInDate == null && filter.Date >= s.ExpectedInDate.Date && filter.Date <= s.ExpectedOutDate.Date))
               )) as IQueryable<Location>;

            return await collection.ToListAsync();


        }
        public  async Task<Location> GetFreeLocationForSpecificPeriodAsync(DateTime start, DateTime end,int diminsion)
        {
            return await _context.Locations
    .Where(l =>
        l.Dimensions >= diminsion &&
        (l.Schedulings.Count == 0 || !l.Schedulings.Any(s =>
            s.ActualOutDate == null &&
            (
               ((s.ActualInDate == null ? s.ExpectedInDate : s.ActualInDate.Value).Date >= start.Date &&
                (s.ActualInDate == null ? s.ExpectedInDate : s.ActualInDate.Value).Date <= end.Date) ||
               ((s.ActualOutDate == null ? s.ExpectedOutDate : s.ActualOutDate.Value).Date >= start.Date &&
                (s.ActualOutDate == null ? s.ExpectedOutDate : s.ActualOutDate.Value).Date <= end.Date)
            )
        ))
    )
    .OrderBy(l => l.Dimensions)
    .FirstOrDefaultAsync();

            //return await _context.Locations.Where(l => (l.Dimensions >= diminsion) && (l.Schedulings.Count == 0 ||
            //   !l.Schedulings.Any(s => s.ActualOutDate == null &&

            //   (

            //     ((s.ActualInDate == null ? s.ExpectedInDate.Date : s.ActualInDate.Value.Date) >= start.Date 
            //     && (s.ActualInDate == null ? s.ExpectedInDate.Date : s.ActualInDate.Value.Date) <= end.Date) ||
            //    ((s.ActualOutDate == null ? s.ExpectedOutDate.Date : s.ActualOutDate.Value.Date) >= start.Date 
            //    && (s.ActualOutDate == null ? s.ExpectedOutDate.Date : s.ActualOutDate.Value.Date) <= end.Date)
            //   )

            //   ))).OrderBy(l => l.Dimensions).FirstOrDefaultAsync();



        }
        public bool ValidDimension(int id,int  dimension)
        {
            return !_context.Locations.Include(l=>l.Schedulings).ThenInclude(s=>s.Package)
                .SingleOrDefault(l=>l.Id==id).Schedulings.Any(s => s.Package.Dimensions>dimension && s.ActualOutDate == null);
        
        
        }
        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await _context.Locations
                .ToListAsync();
        }
        public async Task<Location> GetLocationAsync(int id)
        {
            return await _context.Locations
                .SingleOrDefaultAsync(l => l.Id == id);
        }
        public async Task AddLocationAsync(Location Location)
        {
            _context.Locations
                 .Add(Location);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateLocationAsync(Location Location)
        {
            _context.Entry(Location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public bool LocationExists(int id)
        {
            return (_context.Locations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
