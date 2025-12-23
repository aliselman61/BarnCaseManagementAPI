using BarnCase.Application.Interfaces;
using BarnCase.Domain.Entities;
using BarnCase.Infrastructure.Data;

namespace BarnCase.Application.Services;

public class FarmService : IFarmService
{
    private readonly BarnCaseDbContext _context;

    public FarmService(BarnCaseDbContext context)
    {
        _context = context;
    }

    public int CreateFarm(int userId, string farmName)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
            throw new Exception("User not found");

        var farm = new Farm
        {
            Name = farmName,
            UserId = userId
        };

        _context.Farms.Add(farm);
        _context.SaveChanges();

        return farm.Id;
    }
}
