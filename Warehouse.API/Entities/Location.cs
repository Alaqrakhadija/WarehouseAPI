using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.API.Entities
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Dimensions { get; set; }
        public ICollection<SchedulingProcess> Schedulings { get; set; }

        public ICollection<Package> Packages { get; set; } = new List<Package>();
    }
}
