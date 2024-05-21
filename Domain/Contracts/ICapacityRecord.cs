namespace warehouse_manager.Domain.Contracts
{
    public interface ICapacityRecord
    {
        int Capacity { get; set; }
        int ProductId { get; set; }
    }
}