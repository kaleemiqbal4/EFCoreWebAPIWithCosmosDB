using EFCoreCosmosDB.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCosmosDB.Repository;

public static class ModelBuilderExtensions
{
    public static void ConfigurePartitionKeys(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().ToContainer("Users").HasPartitionKey(u => u.Id);
        modelBuilder.Entity<OrderEntity>().ToContainer("Orders").HasPartitionKey(o => o.Id);
        modelBuilder.Entity<ProductEntity>().ToContainer("Products").HasPartitionKey(p => p.Id);
    }
}
