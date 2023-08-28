using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Domain.Entities
{
    [Table("Customer")]
    public class Customer:User
    {
        
        public ICollection<Package> Packages { get; set; }= new List<Package>();
    }
}
