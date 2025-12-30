using BarnCase.Application.Interfaces;
using BarnCase.Domain.Entities;
using BarnCase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BarnCase.Application.Services;

public class UserService : IUserService
{
    private readonly BarnCaseDbContext _context;

    public UserService(BarnCaseDbContext context)
    {
        _context = context;
    }

    public User CreateUser(string username, decimal initialBalance)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            Balance = initialBalance,
            Role = "User"
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return user;
    }

    public User UpdateUser(Guid userId, decimal balance)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
            throw new Exception("User not found");

        user.Balance = balance;

        _context.SaveChanges();

        return user;
    }

    public void DeleteUser(Guid userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
            throw new Exception("User not found");

        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public User GetById(Guid userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
            throw new Exception("User not found");

        return user;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users.AsNoTracking().ToList();
    }
}
