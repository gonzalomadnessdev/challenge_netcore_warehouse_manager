using Microsoft.EntityFrameworkCore;

namespace warehouse_manager.Repositories.Models
{
    public class WarehouseDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Capacity> Capacity { get; set; }

        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
        { }
    }
}
