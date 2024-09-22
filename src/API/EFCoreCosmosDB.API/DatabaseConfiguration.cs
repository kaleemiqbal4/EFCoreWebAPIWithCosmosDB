using EFCoreCosmosDB.Core;
using EFCoreCosmosDB.Repository.Integration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EFCoreCosmosDB.API;

public static class DatabaseConfiguration
{
    public static void DBRegister(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<CosmosDbOptions>(builder.Configuration.GetSection("CosmosDb"));
        builder.Services.AddDbContext<ApplicationDBContext>((serviceProvider, options) =>
        {
            var cosmosDbOptions = serviceProvider.GetRequiredService<IOptions<CosmosDbOptions>>().Value;
            options.UseCosmos(
                cosmosDbOptions.EndpointUri,
                cosmosDbOptions.PrimaryKey,
                cosmosDbOptions.DatabaseName);
        });
    }
}
