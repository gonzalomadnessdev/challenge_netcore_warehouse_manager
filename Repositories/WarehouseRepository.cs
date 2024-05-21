using System.Linq;
using warehouse_manager.Application.Contracts;
using warehouse_manager.Domain.Contracts;
using warehouse_manager.Domain.Entities;
using warehouse_manager.Repositories.Models;

namespace warehouse_manager.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly WarehouseDbContext _context;
        public WarehouseRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CapacityRecord> GetCapacityRecords()
        {
            var list = _context.CapacityRecord.ToList();

            foreach (var item in list)
            {
                yield return (new CapacityRecord() { ProductId = item.ProductId, Capacity = item.Capacity });
            }
        }

        public IEnumerable<CapacityRecord> GetCapacityRecords(Func<ICapacityRecord, bool> filter)
        {
            var list = _context.CapacityRecord.Where(filter).ToList();

            foreach (var item in list)
            {
                yield return (new CapacityRecord() { ProductId = item.ProductId, Capacity = item.Capacity });
            }
        }

        public IEnumerable<ProductRecord> GetProductRecords()
        {
            var list = _context.ProductRecord.ToList();

            foreach (var item in list)
            {
                yield return (new ProductRecord() { ProductId = item.ProductId, Quantity = item.Quantity });
            }
        }

        public IEnumerable<ProductRecord> GetProductRecords(Func<IProductRecord, bool> filter)
        {
            var list = _context.ProductRecord.Where(filter).ToList();

            foreach (var item in list)
            {
                yield return (new ProductRecord() { ProductId = item.ProductId, Quantity = item.Quantity });
            }
        }

        public void SetCapacityRecord(int productId, int capacity)
        {
            var capacityRecord = _context.CapacityRecord.Single(c => c.ProductId == productId);
            capacityRecord.Capacity = capacity;
            _context.SaveChanges();
        }

        public void SetProductRecord(int productId, int quantity)
        {
            var productRecord = _context.ProductRecord.Single(p => p.ProductId == productId);
            productRecord.Quantity = quantity;
            _context.SaveChanges();
        }
    }
}
