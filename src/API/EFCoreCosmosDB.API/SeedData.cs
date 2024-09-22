using EFCoreCosmosDB.Entity.Entity;
using EFCoreCosmosDB.Repository.Integration;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCosmosDB.API;

public static class SeedData
{
    public static async Task SetSeedData(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

            await context.Database.EnsureCreatedAsync();

            // Seed Users
            if (!await context.Users.AnyAsync())
            {
                context.Users.Add(new UserEntity { Id = "1", Name = "User1", Email = "user1@example.com" });
                await context.SaveChangesAsync();
            }

            // Seed Products
            if (!await context.Products.AnyAsync())
            {
                context.Products.Add(new ProductEntity { Id = "1", Name = "Product1", Price = 9.99m });
                await context.SaveChangesAsync();
            }

            // Seed Orders
            if (!await context.Orders.AnyAsync())
            {
                var order = new OrderEntity
                {
                    Id = "1",
                    UserId = "1",  // Assuming this corresponds to the seeded user
                    OrderDate = DateTime.UtcNow
                };
                context.Orders.Add(order);
                await context.SaveChangesAsync();
            }
        }
    }
}
