using EFCoreCosmosDB.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCosmosDB.Repository.Integration;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext()
    {
        
    }
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<ProductEntity> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultContainer("Items");
        modelBuilder.ConfigurePartitionKeys();
        base.OnModelCreating(modelBuilder);
    }
}

