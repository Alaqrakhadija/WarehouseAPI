namespace Warehouse.API.Models
{
    public class SchedulingForPackageDto
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public DateTime? ActualInDate { get; set; }
        public DateTime? ActualOutDate { get; set; }

    }
}
