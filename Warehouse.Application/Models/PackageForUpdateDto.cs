using System.Text.Json.Serialization;
using static Warehouse.Domain.Entities.Package;

namespace Warehouse.Application.Models
{
    public class PackageForUpdateDto
    {
        public string Type { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Instructions SpecialInstructions { get; set; }
    }
}
