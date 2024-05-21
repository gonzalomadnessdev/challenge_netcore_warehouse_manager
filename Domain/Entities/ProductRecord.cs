using warehouse_manager.Domain.Contracts;

namespace warehouse_manager.Domain.Entities
{
    public class ProductRecord : IProductRecord
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
