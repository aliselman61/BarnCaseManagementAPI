using BarnCase.Application.Interfaces;
using BarnCase.Domain.Entities;
using BarnCase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BarnCase.Application.Services;

public class AnimalService : IAnimalService
{
    private readonly BarnCaseDbContext _context;

    public AnimalService(BarnCaseDbContext context)
    {
        _context = context;
    }

    // NORMAL CREATE (seed / admin vs.)
    public Animal CreateAnimal(string name, string type, int age, decimal price, Guid farmId)
    {
        var animal = new Animal
        {
            Id = Guid.NewGuid(),
            Name = name,
            Type = type,
            Age = age,
            Price = price,
            FarmId = farmId,
            LastProducedAt = DateTime.UtcNow,
            ProductionIntervalInMinutes = 60
        };

        _context.Animals.Add(animal);
        _context.SaveChanges();

        return animal;
    }

    // OYUN MANTIĞI – SATIN ALMA
    public Animal BuyAnimal(Guid farmId, string name, string type, int age, decimal price)
    {
        var farmExists = _context.Farms.Any(f => f.Id == farmId);
        if (!farmExists)
            throw new Exception("Farm not found");

        var animal = new Animal
        {
            Id = Guid.NewGuid(),
            FarmId = farmId,
            Name = name,
            Type = type,
            Age = age,
            Price = price,
            LastProducedAt = DateTime.UtcNow,
            ProductionIntervalInMinutes = 60
        };

        _context.Animals.Add(animal);
        _context.SaveChanges();

        return animal;
    }

    public Animal UpdateAnimal(Guid animalId, decimal price)
    {
        var animal = _context.Animals
            .FirstOrDefault(a => a.Id == animalId)
            ?? throw new Exception("Animal not found");

        animal.Price = price;
        _context.SaveChanges();

        return animal;
    }

    public void DeleteAnimal(Guid animalId)
    {
        var animal = _context.Animals
            .FirstOrDefault(a => a.Id == animalId)
            ?? throw new Exception("Animal not found");

        _context.Animals.Remove(animal);
        _context.SaveChanges();
    }

    public Animal GetById(Guid animalId)
    {
        return _context.Animals
            .AsNoTracking()
            .FirstOrDefault(a => a.Id == animalId)
            ?? throw new Exception("Animal not found");
    }

    public IEnumerable<Animal> GetAll()
    {
        return _context.Animals
            .AsNoTracking()
            .ToList();
    }
}
