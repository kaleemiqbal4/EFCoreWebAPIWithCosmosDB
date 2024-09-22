using EFCoreCosmosDB.Entity.Reponse;
using EFCoreCosmosDB.Entity.Request;

namespace EFCoreCosmosDB.Application.Contract;

public interface IUserManager
{
   Task<int> CreateUserAsync(UserRequest request);

    Task<List<UserResponse>> UsersListAsync();
}
