

namespace Warehouse.Application.Models
{
    public class CustomerGroupPackageDto
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public int Dimensions { get; set; }
        public string SpecialInstructions { get; set; } = string.Empty;
        public SchedulingForPackageDto SchedulingProcess { get; set; }
    }
}
