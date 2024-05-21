using warehouse_manager.Domain.Contracts;

namespace warehouse_manager.Domain.Entities
{
    public class CapacityRecord : ICapacityRecord
    {
        public int ProductId { get; set; }
        public int Capacity { get; set; }
    }
}
