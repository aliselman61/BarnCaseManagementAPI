using BarnCase.Application.Interfaces;
using BarnCase.Domain.Entities;
using BarnCase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BarnCase.Application.Services;

public class FarmService : IFarmService
{
    private readonly BarnCaseDbContext _context;

    public FarmService(BarnCaseDbContext context)
    {
        _context = context;
    }

    public Farm CreateFarm(string name, Guid userId)
    {
        var farm = new Farm
        {
            Id = Guid.NewGuid(),
            Name = name,
            UserId = userId
        };

        _context.Farms.Add(farm);
        _context.SaveChanges();
        return farm;
    }

    public Farm UpdateFarm(Guid farmId, string name)
    {
        var farm = _context.Farms.FirstOrDefault(f => f.Id == farmId)
            ?? throw new Exception("Farm not found");

        farm.Name = name;
        _context.SaveChanges();
        return farm;
    }

    public void DeleteFarm(Guid farmId)
    {
        var farm = _context.Farms.FirstOrDefault(f => f.Id == farmId)
            ?? throw new Exception("Farm not found");

        _context.Farms.Remove(farm);
        _context.SaveChanges();
    }

    public Farm GetById(Guid farmId)
    {
        return _context.Farms
            .AsNoTracking()
            .FirstOrDefault(f => f.Id == farmId)
            ?? throw new Exception("Farm not found");
    }

    public IEnumerable<Farm> GetAll()
    {
        return _context.Farms.AsNoTracking().ToList();
    }
}
