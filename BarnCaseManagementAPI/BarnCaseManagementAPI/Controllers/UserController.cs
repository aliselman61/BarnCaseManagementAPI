using BarnCase.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarnCaseManagementAPI.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult CreateUser(string username, decimal balance)
    {
        var result = _userService.CreateUser(username, balance);
        return Ok(result);
    }
}
