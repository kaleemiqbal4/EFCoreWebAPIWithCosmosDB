using EFCoreCosmosDB.Entity.Entity;
using EFCoreCosmosDB.Repository.Integration.Contract;

namespace EFCoreCosmosDB.Repository.Integration.Concrete;


public class UserRepository(ApplicationDBContext dbContext) : BaseRepository<UserEntity>(dbContext), IUserRepository
{
}
