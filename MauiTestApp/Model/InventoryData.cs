namespace InventoryService.Domain.Model
{
    public class InventoryData
    {
        public string PublicId { get; set; } = string.Empty;
        public string BuggyId { get; set; } = string.Empty;
        public string FarmNo { get; set; } = string.Empty;
        public string FlockNo { get; set; } = string.Empty;
        public string HouseNo { get; set; } = string.Empty;
        public string HatcheryCode { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public string Class { get; set; } = string.Empty;
        public DateTime ProductionDateTime { get; set; } = DateTime.MinValue;
        public string TransType { get; set; } = string.Empty;
        public string DstTransType { get; set; } = string.Empty;
        public string RefNo { get; set; } = string.Empty;
        public string TrackingNo { get; set; } = string.Empty;
        public int TransRecNo { get; set; } = 0;
        public DateTime RecvDateTime { get; set; } = DateTime.Today;
        public DateTime TransactionDateTime { get; init; } = DateTime.MinValue;
        public DateTime InactiveDate { get; init; } = DateTime.MinValue;
        public DateTime LastSetDate { get; set; } = DateTime.MinValue;
        public DateTime HimEggTransRefLastTransDate { get; set; } = DateTime.MinValue;
        public string HimEggTransRefTransCode { get; set; } = string.Empty;
        public bool IsNotAuthorizedTransaction { get; set; } = false;
    }
}
