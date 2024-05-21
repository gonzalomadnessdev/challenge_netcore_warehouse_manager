using warehouse_manager.Domain.Contracts;
using warehouse_manager.Domain.Entities;

namespace warehouse_manager.Application.Contracts
{
    public interface IWarehouseRepository
    {
        void SetCapacityRecord(int productId, int capacity); 
        IEnumerable<CapacityRecord> GetCapacityRecords();
        IEnumerable<CapacityRecord> GetCapacityRecords(Func<ICapacityRecord, bool> filter);
        void SetProductRecord(int productId, int quantity); 
        IEnumerable<ProductRecord> GetProductRecords();
        IEnumerable<ProductRecord> GetProductRecords(Func<IProductRecord, bool> filter);

    }
    
}
