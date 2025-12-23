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

    public int CreateUser(string username, decimal initialBalance)
    {
        var user = new User
        {
            Username = username,
            Balance = initialBalance
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return user.Id;
    }
}
