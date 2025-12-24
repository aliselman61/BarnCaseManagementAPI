namespace BarnCase.Application.Interfaces;

public interface IUserService
{
    object CreateUser(string username, decimal initialBalance);
}
