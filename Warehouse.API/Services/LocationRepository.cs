using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata;
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
    }
}
