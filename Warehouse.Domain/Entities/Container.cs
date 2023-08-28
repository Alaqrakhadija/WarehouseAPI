using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Domain.Entities
{
    public class Container
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public ICollection<SupplierContainer> SupplierContainer { get; set; } = new List<SupplierContainer>();

    }

}
