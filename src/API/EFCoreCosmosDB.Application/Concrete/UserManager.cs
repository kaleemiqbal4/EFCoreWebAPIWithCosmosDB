using EFCoreCosmosDB.Application.Contract;
using EFCoreCosmosDB.Entity.Entity;
using EFCoreCosmosDB.Entity.Reponse;
using EFCoreCosmosDB.Entity.Request;
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
        var entity = new UserEntity()
        {
            Id = "1",
            Name = request.Name,
            Email = request.Email
        };

        await userRepository.AddAsync(entity);
        return 1;
    }

    public async Task<List<UserResponse>> UsersListAsync()
    {
        var result = await userRepository.GetAllAsync();
        var users = new List<UserResponse>();
        result.ToList().ForEach(u => users.Add(new UserResponse()
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email
        }));

        return users;
    }
}
