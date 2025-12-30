using BarnCase.Domain.Entities;

namespace BarnCase.Application.Interfaces;

public interface IAnimalService
{
   Animal BuyAnimal(Guid farmId, string name, string type, int age, decimal price);
   Animal CreateAnimal(string name, string type, int age, decimal price, Guid farmId);
   Animal UpdateAnimal(Guid animalId, decimal price);
   void DeleteAnimal(Guid animalId);
   Animal GetById(Guid animalId);
   IEnumerable<Animal> GetAll();
}
