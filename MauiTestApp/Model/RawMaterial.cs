namespace InventoryService.Domain.Model
{
    public class RawMaterial
    {
        public RawMaterial()
        {
            PublicId = Guid.NewGuid().ToString();
        }

        public string PublicId { get; init; } = string.Empty;
        public RawMaterialClass Class { get; init; } = new();
        public FlockIdentity FlockIdentity { get; init; } = new();
        public Warehouse Warehouse { get; init; } = new();
        public DateTime ProductionDateTime { get; init; } = DateTime.Today;
        public int Quantity { get; init; } = 0;
        public string RefNo { get; init; } = string.Empty;
        public string TrackingNo { get; set; } = string.Empty;
        public int TransRecNo { get; set; } = 0;
        public string TransType { get; set; } = string.Empty;
        public string DstTransType { get; set; } = string.Empty;
        public DateTime RecvDateTime { get; set; } = DateTime.Today;
        public DateTime TransactionDateTime { get; init; } = DateTime.Today;
        public DateTime InactiveDate { get; init; } = new DateTime(1899, 11, 30);
        public DateTime LastSetDate { get; set; } = DateTime.MinValue;
        public DateTime HimEggTransRefLastTransDate { get; set; } = DateTime.MinValue;
        public string HimEggTransRefTransCode { get; set; } = string.Empty;
        public bool IsNotAuthorizedTransaction { get; set; } = false;
    }
}
