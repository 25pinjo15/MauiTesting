using System.Collections.ObjectModel;

namespace InventoryService.Domain.Model
{
    public class Transport
    {
        public string TransportNo { get; set; } = string.Empty;
        public TransportDefinition Definition { get; set; } = new TransportDefinition();
        public Collection<RawMaterial> RawMaterials { get; private set; } = new Collection<RawMaterial>();
        public int CurrentQuantity { get; set; } = 0;
    }
}
