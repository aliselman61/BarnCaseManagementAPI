namespace BarnCase.Application.Interfaces
{
    internal interface IFarmService
    {
        int CreateFarm(int userId, string farmName);
    }
}
