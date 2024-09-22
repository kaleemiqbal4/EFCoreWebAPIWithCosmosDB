using EFCoreCosmosDB.Entity.Entity;
using EFCoreCosmosDB.Repository.Integration.Contract;

namespace EFCoreCosmosDB.Repository.Integration.Concrete;

public class ProductRepository(ApplicationDBContext dbContext) : BaseRepository<ProductEntity>(dbContext), IProductRepository
{
}
