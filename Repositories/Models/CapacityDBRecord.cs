using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace warehouse_manager.Repositories.Models
{
    [Table("Capacity")]
    public class CapacityDBRecord
    {
        [Key]
        public int CapacityId { get; set; }
        public int ProductId { get; set; }
        public int Capacity { get; set; }

        [ForeignKey("ProductId")]
        public ProductDBRecord Product { get; set; } = null!;
    }
}
