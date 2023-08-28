

using System.Text.Json.Serialization;
using static Warehouse.Domain.Entities.Package;

namespace Warehouse.Application.Models
{
    public class PackageForCreationDto
    {
        public int ContainerId { get; set; }

        public int CustomerId { get; set; }
        public string Type { get; set; }
        public int Dimensions { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Instructions SpecialInstructions { get; set; } 

        
        public DateTime ExpectedInDate { get; set; }
        public DateTime ExpectedOutDate { get; set; }
    }
}
