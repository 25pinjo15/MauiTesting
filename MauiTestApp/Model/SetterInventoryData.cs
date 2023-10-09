namespace InventoryService.Domain.Model
{
    public class SetterInventoryData
    {
        public int InfinityRecNo { get; set; }
        public string BuggyId { get; init; } = string.Empty;
        public int EggAge { get; set; }
        public string EggClass { get; set; } = string.Empty;
        public int EggsSet { get; set; }
        public string HatcheryCode { get; init; } = string.Empty;
        public string FarmNo { get; init; } = string.Empty;
        public string HouseNo { get; init; } = string.Empty;
        public string sFlockNo { get; init; } = string.Empty;
        public short FlockAge { get; set; }
        public string RefNo { get; init; } = string.Empty;
        public string TrackingNo { get; set; } = string.Empty;
        public DateTime SetDate { get; init; } = DateTime.MinValue;
        public DateTime ProdDate { get; init; } = DateTime.MinValue;
        public DateTime TransferDate { get; set; }
        public string SetterNo { get; init; } = string.Empty;
    }
}
