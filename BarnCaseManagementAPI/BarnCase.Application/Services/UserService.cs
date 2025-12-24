using BarnCase.Application.Interfaces;
using BarnCase.Domain.Entities;
using BarnCase.Infrastructure.Data;

namespace BarnCase.Application.Services;

public class UserService : IUserService
{
    private readonly BarnCaseDbContext _context;

    public UserService(BarnCaseDbContext context)
    {
        _context = context;
    }

    public object CreateUser(string username, decimal initialBalance)
    {
        var user = new User
        {
            Username = username,
            Balance = initialBalance,
            Role = "User"
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return new
        {
            userId = user.Id,
            username = user.Username
        };
    }
}
