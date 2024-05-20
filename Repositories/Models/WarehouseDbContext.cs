using Microsoft.EntityFrameworkCore;

namespace warehouse_manager.Repositories.Models
{
    public class WarehouseDbContext : DbContext
    {
        public DbSet<ProductDBRecord> ProductRecord { get; set; }
        public DbSet<CapacityDBRecord> CapacityRecord { get; set; }

        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
        { }
    }
}
