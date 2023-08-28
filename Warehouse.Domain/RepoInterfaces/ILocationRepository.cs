using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Entities;

namespace Warehouse.Domain.RepoInterfaces
{
    public interface ILocationRepository
    {
        public Task<IEnumerable<Location>> GetFreeLocationsByDateAsync(DateTime filter);
        public Task<Location> GetFreeLocationForSpecificPeriodAsync(DateTime start, DateTime end, int diminsion);
        public bool ValidDimension(int id, int dimension);
        public Task<IEnumerable<Location>> GetLocationsAsync();
        public Task<Location> GetLocationAsync(int id);
        public Task AddLocationAsync(Location Location);
        public Task UpdateLocationAsync(Location Location);
        public bool LocationExists(int id);
    }
}
