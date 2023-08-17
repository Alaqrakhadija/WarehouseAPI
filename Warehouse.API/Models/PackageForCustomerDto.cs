namespace Warehouse.API.Models
{
    public class PackageForCustomerDto
    {
        public int Id { get; set; }
        public int ContainerId { get; set; }
        public string Type { get; set; }
        public int Dimensions { get; set; }
        public string SpecialInstructions { get; set; } = string.Empty;


    }
}
