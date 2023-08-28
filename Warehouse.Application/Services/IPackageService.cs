using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Application.Models;

namespace Warehouse.Application.Services
{
    public interface IPackageService
    {
        public Task<IEnumerable<PackageDto>>GetPackagesByFilter(string filter);
        public Task<IEnumerable<PackageForGroupingDto>>GetPackagesByPeriod(DateTime start,DateTime end);
        public Task<IEnumerable<PackageForGroupingDto>> GetPackagesGroupByCustomer();
        public Task<PackageDto> AddPackage(PackageForCreationDto package);
        public Task DeleteUnArrivedPackages();
        public Task<PackageDto> GetPackage(int id);
        public Task PutPackage(int id, PackageForUpdateDto package);
    }
}
