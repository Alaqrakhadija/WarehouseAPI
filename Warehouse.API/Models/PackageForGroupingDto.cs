using Warehouse.API.Entities;

namespace Warehouse.API.Models
{
    public class PackageForGroupingDto
    {
        public User Customer { get; set; }
        public IEnumerable<CustomerGroupPackageDto> Packages { get; set; }
    }
}
