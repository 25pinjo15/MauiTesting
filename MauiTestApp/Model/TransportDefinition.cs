using System.ComponentModel.DataAnnotations;

namespace InventoryService.Domain.Model
{
    public class TransportDefinition
    {
        public string PublicId { get; set; } = string.Empty;

        [MaxLength(30)]
        public string Description { get; set; } = string.Empty;
        public string Prefix { get; set; } = string.Empty;
        public int TransportType { get; set; } = 0;
        public uint RawMaterialCapacity { get; set; } = 0;
        public uint TrayOrBoxCount { get; set; } = 0;
        public uint TrayOrBoxCapacity { get; set; } = 0;
        public uint AlveolusCount { get; set; } = 0;
        public uint AlveolusCapacity { get; set; } = 0;
        public uint BoxesPerPallet { get; set; } = 0;
        public bool Boire { get; set; } = false;
        public bool Ovo { get; set; } = false;
        public bool Ovac { get; set; } = false;
        public bool Depot { get; set; } = false;
        public bool Gsk { get; set; } = false;
        public bool Others { get; set; } = false;
    }
}
