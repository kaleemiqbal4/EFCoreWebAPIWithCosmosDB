using EFCoreCosmosDB.Entity.Reponse;
using EFCoreCosmosDB.Entity.Request;

namespace EFCoreCosmosDB.Application.Contract;

public interface IOrderManager
{
    Task<int> CreateOrderAsync(OrderRequest request);

    Task<List<OrderResponse>> OrderListAsync();
}
