using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Domain.Entities
{
    public class Package
    {
        public enum Instructions
        {
            dangerous,
            perishable,
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Dimensions { get; set; }
        public Instructions SpecialInstructions { get; set; }

        public int ContainerId { get; set; }
        public Container Container { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public SchedulingProcess SchedulingProcess { get; set; }


    }
}
