using EFCoreCosmosDB.Application.Contract;
using EFCoreCosmosDB.Entity.Request;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCosmosDB.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserManager userManager;
    private readonly ILogger<UsersController> logger;

    /// <summary> </summary>
    /// <param name="_userManager"></param>
    /// <param name="_logger"></param>
    public UsersController(IUserManager _userManager, ILogger<UsersController> _logger) => (userManager, logger) = (_userManager, _logger);

    [HttpPost]
    public async Task<IActionResult> PostUsersAsync([FromBody] UserRequest userRequest)
    {
        var response = await userManager.CreateUserAsync(userRequest);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        var response = await userManager.UsersListAsync();
        return Ok(response);
    }
}
