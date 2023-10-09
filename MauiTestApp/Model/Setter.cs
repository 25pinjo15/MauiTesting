namespace InventoryService.Domain.Model
{
    public class Setter
    {
        public Setter() { }

        public string PublicId { get; set; } = string.Empty;
        public string SetterCode { get; set; } = string.Empty;
        public string WarehouseCode { get; set; } = string.Empty;
        public int RawMaterialCapacity { get; set; } = 0;
    }
}
