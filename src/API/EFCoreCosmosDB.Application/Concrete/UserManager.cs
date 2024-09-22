using EFCoreCosmosDB.Application.Contract;
using EFCoreCosmosDB.Entity.Entity;
using EFCoreCosmosDB.Entity.Reponse;
using EFCoreCosmosDB.Entity.Request;
using EFCoreCosmosDB.Repository.Integration.Concrete;
using EFCoreCosmosDB.Repository.Integration.Contract;
using Microsoft.Extensions.Logging;

namespace EFCoreCosmosDB.Application.Concrete;

public class UserManager : IUserManager
{
    private readonly IUserRepository userRepository;
    private readonly ILogger<UserManager> logger;

    public UserManager(IUserRepository _userRepository, ILogger<UserManager> _logger) => (userRepository, logger) = (_userRepository, _logger);

    public async Task<int> CreateUserAsync(UserRequest request)
    {
        //var entity = new UserEntity()
        //{
        //    Name = request.Name,
        //    Email = request.Email
        //};

        //await userRepository.AddAsync(entity);
        await Task.CompletedTask;
        return 1;
    }

    public async Task<UserResponse> UsersListAsync()
    {
        // var result = userRepository.GetAllAsync();
        await Task.CompletedTask;
        return default;
    }
}
