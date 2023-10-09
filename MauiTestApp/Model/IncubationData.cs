namespace InventoryService.Domain.Model
{
    public class IncubationData
    {
        public string[] RawMaterialIds { get; set; } = Array.Empty<string>();
        public string SetterCode { get; set; } = string.Empty;
        public DateTime SetDateTime { get; set; } = DateTime.Today;
        public string UserId { get; set; } = string.Empty;
    }
}
