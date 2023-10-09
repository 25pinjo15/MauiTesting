namespace InventoryService.Domain.Model
{
    public class HimEggInventory
    {
        public string ExternalRecNo { get; set; } = string.Empty;
        public int InfinityRecNo { get; set; }
        public string HatcheryCode { get; set; } = string.Empty;
        public string BuggyPrefix { get; set; } = string.Empty;
        public string BuggyId { get; set; } = string.Empty;
        public string EggClass { get; set; } = string.Empty;
        public int Eggs { get; set; }
		public int EggsAge { get; set; } = 0;
		public int TrayCapacity { get; set; }
        public string FarmNo { get; set; } = string.Empty;
        public string HouseNo { get; set; } = string.Empty;
        public string sFlockNo { get; set; } = string.Empty;
        public int FlockAge { get; set; }
        public string RefNo { get; set; } = string.Empty;
        public string TrackingNo { get; set; } = string.Empty;
        public string TransType { get; set; } = string.Empty;
        public string UnitsCode { get; set; } = string.Empty;
        public int TransRecNo { get; set; } = 0;
        public DateTime CreationDate { get; set; } = DateTime.MinValue;
        public DateTime ProdDate { get; set; } = DateTime.MinValue;
        public DateTime RecvDate { get; set; } = DateTime.MinValue;
        public DateTime TransDate { get; set; } = DateTime.MinValue;
        public DateTime InactiveDate { get; set; } = DateTime.MinValue;
        public DateTime LastSetDate { get; set; } = DateTime.MinValue;
        public DateTime HimEggTransRefLastTransDate { get; set;} = DateTime.MinValue;
        public string HimEggTransRefTransCode { get; set; } = string.Empty;
        public bool IsNotAuthorizedTransaction { get; set; } = false;
    }
}
