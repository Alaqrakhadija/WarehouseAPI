
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Models
{
    public class PackageForGroupingDto
    {
        public User Customer { get; set; }
        public IEnumerable<CustomerGroupPackageDto> Packages { get; set; }
    }
}
