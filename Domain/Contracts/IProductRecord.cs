namespace warehouse_manager.Domain.Contracts
{
    public interface IProductRecord
    {
        int ProductId { get; set; }
        int Quantity { get; set; }
    }
}