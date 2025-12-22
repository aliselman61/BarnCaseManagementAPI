using Microsoft.EntityFrameworkCore;
using BarnCase.Domain.Entities;

namespace BarnCase.Infrastructure.Data;

public class BarnCaseDbContext : DbContext
{
    public BarnCaseDbContext(DbContextOptions<BarnCaseDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Farm> Farms => Set<Farm>();
    public DbSet<Animal> Animals => Set<Animal>();
    public DbSet<Product> Products => Set<Product>();
}
