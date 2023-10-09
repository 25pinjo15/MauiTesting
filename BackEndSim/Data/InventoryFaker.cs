using Bogus;
using InventoryService.Domain.Events;
using InventoryService.Domain.Interface;
using InventoryService.Domain.Model;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Application.TestUnit.Helper
{
    public class HardcodedMTechInventoryRepository : IMTechInventoryRepository
    {
        private readonly IMTechReferentialRepository _mtechReferentialRepository;
        private readonly Faker _faker = new();
        private readonly Collection<InventoryData> _inventory = new();
        private readonly Collection<HimEggInventory> _himEggInventory = new();
        private readonly Collection<HimEggInventoryTrans> _himEggInventoryTrans = new();

        public Stack MethodCalls = new();
        public Collection<InventoryData> Inventory => _inventory;

        public HardcodedMTechInventoryRepository(IMTechReferentialRepository mtechReferentialRepository)
        {
            _mtechReferentialRepository = mtechReferentialRepository;

            for (int i = 0; i < _faker.Random.Number(5, 10); i++)
            {
                _inventory.Add(GenerateRandomInventoryData());
                _himEggInventory.Add(GenerateRandomHimEggInventory());
            }

            for (int i = 0; i < _faker.Random.Number(5, 10); i++)
            {
                _himEggInventoryTrans.Add(GenerateRandomHimEggInventoryTrans());
            }
        }

        public Task CreateDisposeListAsync(RawMaterialDisposedCollectionEvent rawMaterialDisposedEvent)
        {
            MethodCalls.Push(nameof(CreateDisposeListAsync));
            return Task.CompletedTask;
        }
        public Task CreateIncubationAsync(RawMaterialIncubatedEvent rawMaterialIncubatedEvent)
        {
            MethodCalls.Push(nameof(CreateIncubationAsync));
            return Task.CompletedTask;
        }

        public Task CreateRawMaterialAsync(RawMaterialCreatedEvent rawMaterialCreatedEvent)
        {
            MethodCalls.Push(nameof(CreateRawMaterialAsync));
            _inventory.Add(new()
            {
                BuggyId = rawMaterialCreatedEvent.TransportNo,
                Class = rawMaterialCreatedEvent.RawMaterial.Class.Code,
                DstTransType = rawMaterialCreatedEvent.RawMaterial.DstTransType,
                FarmNo = rawMaterialCreatedEvent.RawMaterial.FlockIdentity.FarmNo,
                FlockNo = rawMaterialCreatedEvent.RawMaterial.FlockIdentity.FlockNo,
                HatcheryCode = rawMaterialCreatedEvent.RawMaterial.Warehouse.Code,
                HouseNo = rawMaterialCreatedEvent.RawMaterial.FlockIdentity.HouseNo,
                InactiveDate = rawMaterialCreatedEvent.RawMaterial.InactiveDate,
                ProductionDateTime = rawMaterialCreatedEvent.RawMaterial.ProductionDateTime,
                PublicId = rawMaterialCreatedEvent.RawMaterial.PublicId,
                Quantity = rawMaterialCreatedEvent.RawMaterial.Quantity,
                RecvDateTime = rawMaterialCreatedEvent.RawMaterial.RecvDateTime,
                RefNo = rawMaterialCreatedEvent.RawMaterial.RefNo,
                TrackingNo = rawMaterialCreatedEvent.RawMaterial.TrackingNo,
                TransactionDateTime = rawMaterialCreatedEvent.RawMaterial.TransactionDateTime,
                TransRecNo = rawMaterialCreatedEvent.RawMaterial.TransRecNo
            });
            return Task.CompletedTask;
        }

        public Task<Guid> CreateRegradeAsync(RawMaterialRegradedEvent rawMaterialRegradedEvent)
        {
            MethodCalls.Push(nameof(CreateRegradeAsync));

            var newGuid = Guid.NewGuid();

            if (rawMaterialRegradedEvent.NewClassCode.ToLower() == "cs")
            {
                var parentInventoryData = GetRawMaterialByPublicId(rawMaterialRegradedEvent.RawMaterial.PublicId).GetAwaiter().GetResult();
                parentInventoryData.PublicId = newGuid.ToString();
                Inventory.Add(parentInventoryData);
            }

            return Task.FromResult(newGuid);
        }

        public Task CreateRepackAsync(RawMaterialRepackedEvent rawMaterialRepackedEvent)
        {
            MethodCalls.Push(nameof(CreateRepackAsync));
            return Task.CompletedTask;
        }

        public Task CreateTransferAsync(RawMaterialTransferedEvent rawMaterialTransferedEvent)
        {
            MethodCalls.Push(nameof(CreateTransferAsync));
            return Task.CompletedTask;
        }

        public Task<bool> DeleteRawMaterial(int transRecNo) =>
            Task.FromResult(_inventory.Any(x => x.TransRecNo == transRecNo));

        public Task<bool> ExistRawMaterialByPublicId(string publicId) =>
            Task.FromResult(_inventory.Any(x => x.PublicId == publicId));

        public Task<bool> ExistTransportByTransportNo(string transportNo) =>
            Task.FromResult(_inventory.Any(x => x.BuggyId == transportNo));

        public Task<Collection<HimEggInventory>> GetHimEggInventoryByAsync(DateTime date, string hatcheryCode, string farmNo)
        {
            if (!string.IsNullOrWhiteSpace(hatcheryCode) && string.IsNullOrEmpty(farmNo))
                return Task.FromResult(new Collection<HimEggInventory>(_himEggInventory.Where(x => x.HatcheryCode == hatcheryCode).ToList()));
            if (!string.IsNullOrWhiteSpace(hatcheryCode) && !string.IsNullOrWhiteSpace(farmNo))
                return Task.FromResult(new Collection<HimEggInventory>(_himEggInventory.Where(x => x.HatcheryCode == hatcheryCode && x.FarmNo == farmNo).ToList()));

            return Task.FromResult(_himEggInventory);
        }

        public Task<Collection<InventoryData>> GetInventoryByDateAndFarmNoAndHatcheryCodeAsync(DateTime date, string farmNo, string hatcheryCode) =>
            Task.FromResult(new Collection<InventoryData>(_inventory.Where(x => x.FarmNo == farmNo && x.HatcheryCode == hatcheryCode).ToList()));

        public Task<Collection<InventoryData>> GetInventoryByDateAndFarmNoAsync(DateTime date, string farmNo) =>
            Task.FromResult(new Collection<InventoryData>(_inventory.Where(x => x.FarmNo == farmNo).ToList()));

        public Task<Collection<InventoryData>> GetInventoryByDateAndHatcheryCodeAsync(DateTime date, string hatcheryCode) =>
            Task.FromResult(new Collection<InventoryData>(_inventory.Where(x => x.HatcheryCode == hatcheryCode).ToList()));

        public Task<Collection<InventoryData>> GetInventoryByDateAsync(DateTime date) =>
            Task.FromResult(_inventory);

        public Task<InventoryData> GetRawMaterialByPublicId(string publicId) =>
            Task.FromResult(_inventory.First(x => x.PublicId == publicId));

        public Task<Collection<HimEggInventoryTrans>> GetSellRawMaterialTransactionsAsync(DateTime date, string hatcheryCode, string farmNo)
        {
            if (!string.IsNullOrWhiteSpace(hatcheryCode) && string.IsNullOrEmpty(farmNo))
                return Task.FromResult(new Collection<HimEggInventoryTrans>(_himEggInventoryTrans.Where(x => x.HatcheryCode == hatcheryCode).ToList()));

            if (!string.IsNullOrWhiteSpace(hatcheryCode) && !string.IsNullOrWhiteSpace(farmNo))
                return Task.FromResult(new Collection<HimEggInventoryTrans>(_himEggInventoryTrans.Where(x => x.HatcheryCode == hatcheryCode && x.FarmNo == farmNo).ToList()));

            return Task.FromResult(_himEggInventoryTrans);
        }

        public Task<Collection<HimEggInventoryTrans>> GetDisposeRawMaterialTransactionsAsync(DateTime date, string hatcheryCode, string farmNo)
        {
            if (!string.IsNullOrWhiteSpace(hatcheryCode) && string.IsNullOrEmpty(farmNo))
                return Task.FromResult(new Collection<HimEggInventoryTrans>(_himEggInventoryTrans.Where(x => x.HatcheryCode == hatcheryCode).ToList()));

            if (!string.IsNullOrWhiteSpace(hatcheryCode) && !string.IsNullOrWhiteSpace(farmNo))
                return Task.FromResult(new Collection<HimEggInventoryTrans>(_himEggInventoryTrans.Where(x => x.HatcheryCode == hatcheryCode && x.FarmNo == farmNo).ToList()));

            return Task.FromResult(_himEggInventoryTrans);
        }

        public Task<Collection<HimEggInventoryTrans>> GetRegradeRawMaterialTransactionsAsync(DateTime date, string hatcheryCode, string farmNo)
        {
            if (!string.IsNullOrWhiteSpace(hatcheryCode) && string.IsNullOrEmpty(farmNo))
                return Task.FromResult(new Collection<HimEggInventoryTrans>(_himEggInventoryTrans.Where(x => x.HatcheryCode == hatcheryCode).ToList()));

            if (!string.IsNullOrWhiteSpace(hatcheryCode) && !string.IsNullOrWhiteSpace(farmNo))
                return Task.FromResult(new Collection<HimEggInventoryTrans>(_himEggInventoryTrans.Where(x => x.HatcheryCode == hatcheryCode && x.FarmNo == farmNo).ToList()));

            return Task.FromResult(_himEggInventoryTrans);
        }

        public Task<Collection<HimEggInventoryTrans>> GetRepackRawMaterialTransactionsAsync(DateTime date, string hatcheryCode, string farmNo)
        {
            if (!string.IsNullOrWhiteSpace(hatcheryCode) && string.IsNullOrEmpty(farmNo))
                return Task.FromResult(new Collection<HimEggInventoryTrans>(_himEggInventoryTrans.Where(x => x.HatcheryCode == hatcheryCode).ToList()));

            if (!string.IsNullOrWhiteSpace(hatcheryCode) && !string.IsNullOrWhiteSpace(farmNo))
                return Task.FromResult(new Collection<HimEggInventoryTrans>(_himEggInventoryTrans.Where(x => x.HatcheryCode == hatcheryCode && x.FarmNo == farmNo).ToList()));

            return Task.FromResult(_himEggInventoryTrans);
        }

        public Task<Collection<HimEggInventoryTrans>> GetTransferRawMaterialTransactionsAsync(DateTime date, string hatcheryCode, string farmNo)
        {
            if (!string.IsNullOrWhiteSpace(hatcheryCode) && string.IsNullOrEmpty(farmNo))
                return Task.FromResult(new Collection<HimEggInventoryTrans>(_himEggInventoryTrans.Where(x => x.HatcheryCode == hatcheryCode).ToList()));

            if (!string.IsNullOrWhiteSpace(hatcheryCode) && !string.IsNullOrWhiteSpace(farmNo))
                return Task.FromResult(new Collection<HimEggInventoryTrans>(_himEggInventoryTrans.Where(x => x.HatcheryCode == hatcheryCode && x.FarmNo == farmNo).ToList()));

            return Task.FromResult(_himEggInventoryTrans);
        }

        private InventoryData GenerateRandomInventoryData()
        {
            var flockIdentity = _faker.PickRandom(_mtechReferentialRepository.GetFlocksAsync(DateTime.Today).GetAwaiter().GetResult());
            var buggyId = _faker.PickRandom(_mtechReferentialRepository.GetTransportDefinitionsAsync().GetAwaiter().GetResult()).Prefix +
                _faker.Random.Int(1000, 9999);

            return new()
            {
                PublicId = _faker.Random.AlphaNumeric(10),
                BuggyId = buggyId,
                Class = _faker.PickRandom(_mtechReferentialRepository.GetRawMaterialClassesAsync().GetAwaiter().GetResult()).Code,
                FarmNo = flockIdentity.FarmNo,
                FlockNo = flockIdentity.FlockNo,
                HouseNo = flockIdentity.HouseNo,
                HatcheryCode = _faker.PickRandom(_mtechReferentialRepository.GetWarehousesAsync().GetAwaiter().GetResult()).Code,
                ProductionDateTime = DateTime.Today,
                Quantity = _faker.Random.Number(1000, 2000),
                TransRecNo = _faker.Random.Number(10000, 50000)
            };
        }

        private HimEggInventory GenerateRandomHimEggInventory()
        {
            var flockIdentity = _faker.PickRandom(_mtechReferentialRepository.GetFlocksAsync(DateTime.Today).GetAwaiter().GetResult());
            var buggyId = _faker.PickRandom(_mtechReferentialRepository.GetTransportDefinitionsAsync().GetAwaiter().GetResult()).Prefix +
                _faker.Random.Int(1000, 9999);

            return new()
            {
                BuggyId = buggyId,
                CreationDate = DateTime.Today,
                EggClass = _faker.PickRandom(_mtechReferentialRepository.GetRawMaterialClassesAsync().GetAwaiter().GetResult()).Code,
                Eggs = _faker.Random.Number(1, 100),
                ExternalRecNo = _faker.Random.Uuid().ToString(),
                FarmNo = flockIdentity.FarmNo,
                HatcheryCode = _faker.PickRandom(_mtechReferentialRepository.GetWarehousesAsync().GetAwaiter().GetResult()).Code,
                HouseNo = flockIdentity.HouseNo,
                sFlockNo = flockIdentity.FlockNo,
                TransRecNo = _faker.Random.Number(10000, 50000)
            };
        }

        private HimEggInventoryTrans GenerateRandomHimEggInventoryTrans()
        {
            var flockIdentity = _faker.PickRandom(_mtechReferentialRepository.GetFlocksAsync(DateTime.Today).GetAwaiter().GetResult());
            var buggyId = _faker.PickRandom(_mtechReferentialRepository.GetTransportDefinitionsAsync().GetAwaiter().GetResult()).Prefix + _faker.Random.Int(1000, 9999);
            var infinityRecNo = _faker.Random.Int(1000, 9999);

            return new()
            {
                InfinityRecNo = infinityRecNo,
                BuggyId = buggyId,
                TransDate = DateTime.Today,
                EggClass = _faker.PickRandom(_mtechReferentialRepository.GetRawMaterialClassesAsync().GetAwaiter().GetResult()).Code,
                TrsEggs = _faker.Random.Number(1, 100),
                FarmNo = flockIdentity.FarmNo,
                HatcheryCode = _faker.PickRandom(_mtechReferentialRepository.GetWarehousesAsync().GetAwaiter().GetResult()).Code,
                HouseNo = flockIdentity.HouseNo,
                sFlockNo = flockIdentity.FlockNo,
            };
        }

        public Task CreateTransferListAsync(RawMaterialTransferedCollectionEvent rawMaterialTransferedEvent)
        {
			MethodCalls.Push(nameof(CreateTransferListAsync));
			return Task.CompletedTask;
		}

        public Task<bool> TransportAvailable(DateTime date, string transportNo)
        {
			return Task.FromResult(true);
		}

		public Task<int> GetCurrentQuantityByTransportNo(string transportNo)
		{
            return Task.FromResult(1);
		}
	}
}
