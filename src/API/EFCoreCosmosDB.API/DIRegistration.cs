using EFCoreCosmosDB.Application.Concrete;
using EFCoreCosmosDB.Application.Contract;
using EFCoreCosmosDB.Repository.Integration.Concrete;
using EFCoreCosmosDB.Repository.Integration.Contract;

namespace EFCoreCosmosDB.API;

public static class DIRegistration
{
    public static WebApplicationBuilder AddDIRegistration(this WebApplicationBuilder builder)
    {
        #region
        builder.Services.AddScoped<IUserManager, UserManager>();
        builder.Services.AddScoped<IOrderManager, OrderManager>();
        builder.Services.AddScoped<IProductManager, ProductManager>();
        #endregion

        #region
        builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        #endregion

        return builder;
    }
}
