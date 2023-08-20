namespace Warehouse.API.Models
{
    public class PackageForUpdateDto
    {
        public string Type { get; set; }
        public string SpecialInstructions { get; set; } = string.Empty;
    }
}
