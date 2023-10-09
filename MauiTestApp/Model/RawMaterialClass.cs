namespace InventoryService.Domain.Model
{
    public class RawMaterialClass
    {
        public string PublicId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }
}
