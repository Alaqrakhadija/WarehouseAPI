using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Entities;

namespace Warehouse.Domain.RepoInterfaces
{
    public interface IPackageRepository
    {
        public Task<IEnumerable<Package>> GetPackagesByFilterAsync(string filter);
        public Task<Package> GetPackageAsync(int id);
        public Task<IEnumerable<IGrouping<Customer, Package>>> GetPackagesByPeriodAsync(DateTime start, DateTime end);
        public Task<IEnumerable<IGrouping<Customer, Package>>> GetPackagesGroupByCustomerAsync();
        public Task DeletePackagesAsync();
        public Task AddPackageAsync(Package package);
        public Task UpdatePackageAsync(Package package);
        public bool PackageExists(int id);
    }
}
