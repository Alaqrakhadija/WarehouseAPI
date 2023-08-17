using Warehouse.API.Entities;

namespace Warehouse.API.Models
{
    public class PackageDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Dimensions { get; set; }
        public string SpecialInstructions { get; set; } = string.Empty;

        public int ContainerId { get; set; }
        public int CustomerId { get; set; }
        public SchedulingForPackageDto SchedulingProcess { get; set; }
    }
}