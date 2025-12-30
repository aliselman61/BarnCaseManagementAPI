using BarnCase.Domain.Entities;

namespace BarnCase.Application.Interfaces;

public interface IUserService
{
    User CreateUser(string username, decimal initialBalance);

    User UpdateUser(Guid userId, decimal balance);

    void DeleteUser(Guid userId);

    User GetById(Guid userId);

    IEnumerable<User> GetAll();
}
