using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using warehouse_manager.Domain.Contracts;

namespace warehouse_manager.Repositories.Models
{
    [Table("Capacity")]
    public class CapacityDBRecord : ICapacityRecord
    {
        [Key]
        public int CapacityId { get; set; }
        public int ProductId { get; set; }
        public int Capacity { get; set; }

        [ForeignKey("ProductId")]
        public ProductDBRecord Product { get; set; } = null!;
    }
}
