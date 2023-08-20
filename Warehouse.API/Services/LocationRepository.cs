using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Warehouse.API.DbContexts;
using Warehouse.API.Entities;

namespace Warehouse.API.Services
{
    public class LocationRepository
    {
        private readonly WarehouseContext _context;
        private readonly ILogger<LocationRepository> _logger;

        public LocationRepository(WarehouseContext context, ILogger<LocationRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException( nameof(logger));

        }
        public async Task<IEnumerable<Entities.Location>> GetFreeLocationsByDateAsync(DateTime filter)
        {

            var collection = _context.Locations.Where(l => l.Schedulings.Count == 0 ||
               !l.Schedulings.Any(s => s.ActualOutDate == null &&

               ((s.ActualInDate != null && (filter.Date>=s.ActualInDate.Value.Date && filter.Date <= s.ExpectedOutDate.Date)) ||
                (s.ActualInDate == null && filter.Date >= s.ExpectedInDate.Date && filter.Date <= s.ExpectedOutDate.Date))
               )) as IQueryable<Entities.Location>;

            return await collection.ToListAsync();


        }
        public  async Task<Entities.Location> GetFreeLocationForSpecificPeriodAsync(DateTime start, DateTime end,int diminsion)
        {


            return await _context.Locations.Where(l => (l.Dimensions >= diminsion) && (l.Schedulings.Count == 0 ||
               !l.Schedulings.Any(s =>
                 (s.ExpectedInDate.Date >= start.Date && s.ExpectedInDate.Date <= end.Date) ||
                (s.ExpectedOutDate.Date >= start.Date && s.ExpectedOutDate.Date <= end.Date)
               ))).OrderBy(l => l.Dimensions).FirstOrDefaultAsync();



        }
        public bool ValidDimension(int id,int  dimension)
        {
            return !_context.Locations.Include(l=>l.Schedulings).ThenInclude(s=>s.Package)
                .SingleOrDefault(l=>l.Id==id).Schedulings.Any(s => s.Package.Dimensions>dimension && s.ActualOutDate == null);
        
        
        }
        public async Task<IEnumerable<Entities.Location>> GetLocationsAsync()
        {
            return await _context.Locations
                .ToListAsync();
        }
        public async Task<Entities.Location> GetLocationAsync(int id)
        {
            return await _context.Locations
                .SingleOrDefaultAsync(l => l.Id == id);
        }
        public async Task AddLocationAsync(Entities.Location Location)
        {
            _context.Locations
                 .Add(Location);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateLocationAsync(Entities.Location Location)
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
