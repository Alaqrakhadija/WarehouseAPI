using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.API.Entities
{
    [Table("Supplier")]
    public class Supplier:User
    {
       
        public ICollection<SupplierContainer> SupplierContainer { get; set; }=new List<SupplierContainer>();

    }
}
