using BarnCase.Application.Interfaces;
using BarnCase.Domain.Entities;
using BarnCase.Infrastructure.Data;

namespace BarnCase.Application.Services;

public class AnimalService : IAnimalService
{
    private readonly BarnCaseDbContext _context;

    public AnimalService(BarnCaseDbContext context)
    {
        _context = context;
    }

    public void BuyAnimal(int userId, int farmId, string animalType)
    {
        
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
            throw new Exception("User not found");

        
        var farm = _context.Farms.FirstOrDefault(f => f.Id == farmId && f.UserId == userId);
        if (farm == null)
            throw new Exception("Farm not found");
        
        const decimal animalPrice = 100;

        if (user.Balance < animalPrice)
            throw new Exception("Insufficient balance");

        user.Balance -= animalPrice;

        var animal = new Animal
        {
            Type = animalType,
            CreatedAt = DateTime.UtcNow,
            LifeTimeInDays = 30,
            ProductionIntervalInHours = 6,
            FarmId = farm.Id
        };

        _context.Animals.Add(animal);

       
        _context.SaveChanges();
    }
}