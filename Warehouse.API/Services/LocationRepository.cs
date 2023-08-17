using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata;
using Warehouse.API.DbContexts;
using Warehouse.API.Entities;

namespace Warehouse.API.Services
{
    public class LocationRepository
    {
        private readonly WarehouseContext _context;
        public LocationRepository(WarehouseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Entities.Location>> GetFreeLocationsByDateAsync(DateTime filter)
        {



            var collection = _context.Locations.Where(l => l.Schedulings.Count==0 ||
               !l.Schedulings.Any(s => s.ActualOutDate == null &&

               (
                   (
                     s.ActualInDate != null && s.ActualInDate.Value.Date == filter.Date
                   )
                   ||
                   (
                      filter.Date == s.ExpectedInDate.Date ||
                      (
                        filter < s.ExpectedOutDate.Date && filter > s.ExpectedInDate.Date
                      )
                    )
              )
               )) as IQueryable<Entities.Location>;

            return await collection.ToListAsync();
           

        }
    }
}
