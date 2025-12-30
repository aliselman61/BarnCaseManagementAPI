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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Username)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(u => u.Role)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(u => u.Balance)
                  .HasPrecision(18, 2);
        });

       
        modelBuilder.Entity<Farm>(entity =>
        {
            entity.HasKey(f => f.Id);

            entity.Property(f => f.Name)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.HasOne(f => f.User)
                  .WithMany(u => u.Farms)
                  .HasForeignKey(f => f.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

      
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(a => a.Type)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(a => a.Price)
                  .HasPrecision(18, 2);

            entity.Property(a => a.LastProducedAt)
                  .IsRequired();

            entity.Property(a => a.ProductionIntervalInMinutes)
                  .IsRequired();

            entity.HasOne(a => a.Farm)
                  .WithMany(f => f.Animals)
                  .HasForeignKey(a => a.FarmId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

     
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.Property(p => p.Price)
                  .HasPrecision(18, 2);

            entity.Property(p => p.ProducedAt)
                  .IsRequired();

            entity.HasOne(p => p.Animal)
                  .WithMany()
                  .HasForeignKey(p => p.AnimalId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
