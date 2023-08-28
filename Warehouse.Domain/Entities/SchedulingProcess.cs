using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Domain.Entities
{
    public class SchedulingProcess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime ExpectedInDate { get; set; }
        [Required]
        public DateTime ExpectedOutDate { get; set; }
        public DateTime? ActualInDate { get; set; }
        public DateTime? ActualOutDate { get; set; }
        public int PackageId { get; set; }
        public Package  Package { get; set; }
        public int LocationId { get; set; }

    }
}
