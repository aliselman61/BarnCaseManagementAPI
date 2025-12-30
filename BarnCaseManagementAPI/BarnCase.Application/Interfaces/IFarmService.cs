using BarnCase.Domain.Entities;

public interface IFarmService
{
    Farm CreateFarm(string name, Guid userId);
    Farm UpdateFarm(Guid farmId, string name);   
    void DeleteFarm(Guid farmId);
    Farm GetById(Guid farmId);
    IEnumerable<Farm> GetAll();
}
