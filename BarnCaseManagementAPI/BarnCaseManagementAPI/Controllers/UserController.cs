using BarnCase.Application.Interfaces;
using BarnCaseManagementAPI.Models;
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

    // POST api/users
    [HttpPost]
    public IActionResult Create([FromBody] CreateUserDto dto)
    {
        var user = _userService.CreateUser(dto.Username, dto.Balance);

        return Ok(new UserResponseDto
        {
            Id = user.Id,
            Username = user.Username,
            Balance = user.Balance,
            Role = user.Role
        });
    }

    // PUT api/users/{userId}
    [HttpPut("{userId:guid}")]
    public IActionResult Update(Guid userId, [FromBody] UpdateUserDto dto)
    {
        var user = _userService.UpdateUser(userId, dto.Balance);

        return Ok(new UserResponseDto
        {
            Id = user.Id,
            Username = user.Username,
            Balance = user.Balance,
            Role = user.Role
        });
    }

    // DELETE api/users/{userId}
    [HttpDelete("{userId:guid}")]
    public IActionResult Delete(Guid userId)
    {
        _userService.DeleteUser(userId);
        return NoContent();
    }

    // GET api/users/{userId}
    [HttpGet("{userId:guid}")]
    public IActionResult GetById(Guid userId)
    {
        var user = _userService.GetById(userId);

        return Ok(new UserResponseDto
        {
            Id = user.Id,
            Username = user.Username,
            Balance = user.Balance,
            Role = user.Role
        });
    }

    // GET api/users
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();

        var response = users.Select(user => new UserResponseDto
        {
            Id = user.Id,
            Username = user.Username,
            Balance = user.Balance,
            Role = user.Role
        });

        return Ok(response);
    }
}
