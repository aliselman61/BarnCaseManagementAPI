namespace BarnCase.Application.Interfaces;

public interface IAnimalService
{
    void BuyAnimal(int userId, int farmId, string animalType);
}
