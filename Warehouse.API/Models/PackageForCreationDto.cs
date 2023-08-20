using System.ComponentModel.DataAnnotations.Schema;
using Warehouse.API.Entities;

namespace Warehouse.API.Models
{
    public class PackageForCreationDto
    {
        public int ContainerId { get; set; }

        public int CustomerId { get; set; }
        public string Type { get; set; }
        public int Dimensions { get; set; }
        public string SpecialInstructions { get; set; } = string.Empty;

        
        public DateTime ExpectedInDate { get; set; }
        public DateTime ExpectedOutDate { get; set; }
    }
}
