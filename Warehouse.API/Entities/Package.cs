using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.API.Entities
{
    public class Package
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Dimensions { get; set; }
        public string SpecialInstructions { get; set; }=string.Empty;

        public int ContainerId { get; set; }
        public Container Container { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public SchedulingProcess SchedulingProcess { get; set; }


    }
}
