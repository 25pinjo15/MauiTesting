using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryService.Domain.Model;

namespace MauiTestApp.Data
{
	internal class DataFaker
	{
		public RawMaterial[] RawMaterials { get; set; }
		public HimEggInventory[] HimEggInventories { get; set; }
		public FlockIdentity[] FlockIdentities { get; set; }
		public HimEggInventoryTrans[] HimEggInventoryTrans { get; set; }

		


		public RawMaterial[] FakeRawMaterial()
		{
			var returnList = new List<RawMaterial>();



			return returnList.ToArray();
		}

		public void FakeHimEggInventory()
		{

		}

		public FlockIdentity[] FakeFlockIdentity()
		{
			var returnList = new List<FlockIdentity>();

			returnList.Add(new FlockIdentity
			{
				PublicId = "1",
				FarmNo = "1",
				FarmName = "Farm 1",
				FlockNo = "1",
				HouseNo = "1",
				PenNo = "1",
				Code = "1",
				DateSold = DateTime.Now,
				DateSoldWithExtraDays = DateTime.Now,
				PrimaryHatchery = "",
				DatePlaced = DateTime.Now
			});

			return returnList.ToArray();

		}

		public void FakeHimEggInventoryTrans()
		{

		}
	}
}
