using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using warehouse_manager.Domain.Contracts;

namespace warehouse_manager.Repositories.Models
{
    [Table("Product")]
    public class ProductDBRecord : IProductRecord
    {
        [Key]
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
