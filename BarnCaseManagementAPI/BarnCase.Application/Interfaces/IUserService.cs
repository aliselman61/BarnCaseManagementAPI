namespace BarnCase.Application.Interfaces;

public interface IUserService
{
    int CreateUser(string username, decimal initialBalance);
}
