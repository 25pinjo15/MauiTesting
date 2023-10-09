using System.ComponentModel.DataAnnotations;

namespace InventoryService.Domain.Model
{
    public class Warehouse
    {
        public string PublicId { get; set; } = string.Empty;

        [MaxLength(40)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(10)]
        public string Code { get; set; } = string.Empty;
        public string FacilityCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }
}
