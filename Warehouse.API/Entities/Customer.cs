using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.API.Entities
{
    [Table("Customer")]
    public class Customer:User
    {
        
        public ICollection<Package> Packages { get; set; }= new List<Package>();
    }
}
