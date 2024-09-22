using EFCoreCosmosDB.Entity.Entity;
using EFCoreCosmosDB.Repository.Integration;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCosmosDB.API;

public static class ServiceAndPipeLineDependencies
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.DBRegister();
        builder.AddDIRegistration();
        return builder;
    }

    public static WebApplication ConfigurePipeLine(this WebApplication app)
    {
        _ = app.SetSeedData();
        return app;
    }

   
}
