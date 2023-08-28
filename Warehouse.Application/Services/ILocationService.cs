using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Application.Models;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Services
{
    public interface ILocationService
    {
        public Task<IEnumerable<LocationDto>> GetFreeLocations(DateTime filter);
        public  Task<LocationDto> GetLocation(int id);
        public Task PutLocation(int id, LocationForCreateUpdateDto location);
        public Task<LocationDto> PostLocation(LocationForCreateUpdateDto location);
        public Task DeleteLocation(int id);
        public Task<Location> GetFreeLocationForSpecificPeriod(DateTime start, DateTime end, int diminsion);
    }
}
