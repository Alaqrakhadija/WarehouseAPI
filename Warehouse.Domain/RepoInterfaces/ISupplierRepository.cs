
using Warehouse.Domain.Entities;

namespace Warehouse.Domain.RepoInterfaces
{
    public interface ISupplierRepository
    {
        public Task<IEnumerable<Supplier>> GetSuppliersAsync();
        public Task<Supplier> GetSupplierAsync(int id);
        public Task PutSupplierAsync(Supplier supplier);
        public Task PostSupplierAsync(Supplier supplier);
        public bool SupplierExists(int id);
    }
}
