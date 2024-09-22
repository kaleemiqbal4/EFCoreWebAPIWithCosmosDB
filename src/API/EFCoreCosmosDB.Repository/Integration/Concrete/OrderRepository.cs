using EFCoreCosmosDB.Entity.Entity;
using EFCoreCosmosDB.Repository.Integration.Contract;

namespace EFCoreCosmosDB.Repository.Integration.Concrete;

public class OrderRepository(ApplicationDBContext dbContext) : BaseRepository<OrderEntity>(dbContext), IOrderRepository
{
}
