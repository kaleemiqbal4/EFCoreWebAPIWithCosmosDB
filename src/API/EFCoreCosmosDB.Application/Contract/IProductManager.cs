using EFCoreCosmosDB.Entity.Reponse;
using EFCoreCosmosDB.Entity.Request;

namespace EFCoreCosmosDB.Application.Contract;

public interface IProductManager
{
    Task<int> CreateProductAsync(ProductRequest request);

    Task<List<ProductResponse>> ProductListAsync();
}
