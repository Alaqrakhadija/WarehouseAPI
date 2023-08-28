using System.Text.Json.Serialization;
using static Warehouse.Domain.Entities.Package;

namespace Warehouse.Application.Models
{
    public class PackageForCustomerDto
    {
        public int Id { get; set; }
        public int ContainerId { get; set; }
        public string Type { get; set; }
        public int Dimensions { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Instructions SpecialInstructions { get; set; }


    }
}
