using warehouse_manager.Application.Contracts;
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
            throw new NotImplementedException();
        }

        public IEnumerable<CapacityRecord> GetCapacityRecords(Func<CapacityRecord, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductRecord> GetProductRecords()
        {
            var list = _context.ProductRecord.ToList();

            foreach (var item in list)
            {
                yield return (new ProductRecord() { ProductId = item.ProductId, Quantity = item.Quantity });
            }
        }

        public IEnumerable<ProductRecord> GetProductRecords(Func<ProductRecord, bool> filter)
        {
            var list = _context.ProductRecord.Where((Func<ProductDBRecord, bool>)filter).ToList();

            foreach (var item in list)
            {
                yield return (new ProductRecord() { ProductId = item.ProductId, Quantity = item.Quantity });
            }
        }

        public void SetCapacityRecord(int productId, int capacity)
        {
            throw new NotImplementedException();
        }

        public void SetProductRecord(int productId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
