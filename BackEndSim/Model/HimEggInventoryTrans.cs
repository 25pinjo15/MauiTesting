using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Domain.Model
{
    public class HimEggInventoryTrans
    {
        public int InfinityRecNo { get; set; }
        public string FarmNo { get; set; } = string.Empty;
        public string HatcheryCode { get; set; } = string.Empty;
		public string HatecheryCodeSource { get; set; } = string.Empty;
		public int EggTransRecNoSource { get; set; }
		public string HouseNo { get; set; } = string.Empty;
        public string GrowoutArea { get; set; } = string.Empty;
        public string sFlockNo { get; set; } = string.Empty;
        public int EggsAge { get; set; } = 0;
        public string EggClass { get; set; } = string.Empty;
		public string EggClassSource { get; set; } = string.Empty;
		public string BuggyId { get; set; } = string.Empty;
		public string BuggyIdSource { get; set; } = string.Empty;
		public string TransCode { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime ProdDate { get; set; }  
        public int TrsEggTransIdII { get; set; }
        public string TrackingNo { get; set; } = string.Empty;
        public string RefNo { get; set; } = string.Empty;
        public string UnitsCode { get; set; } = string.Empty;
        public int TrsEggs { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int BlockingDstTransRecNo { get; set; } = 0;
    }
}
