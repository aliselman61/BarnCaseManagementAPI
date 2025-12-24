using BarnCase.Application.Interfaces;
using BarnCase.Domain.Entities;
using BarnCase.Infrastructure.Data;
 
namespace BarnCase.Application.Services;

public class ProductService : IProductService
{
    private readonly BarnCaseDbContext _context;

    public ProductService(BarnCaseDbContext context)
    {
        _context = context;
    }

    public void ProduceProducts()
    {
        var now = DateTime.UtcNow;
         
        var animals = _context.Animals.ToList();

        foreach (var animal in animals)
        {
            var lastProduced = animal.LastProducedAt ?? animal.CreatedAt;
            var hoursPassed = (now - lastProduced).TotalHours;

            if (hoursPassed >= animal.ProductionIntervalInHours)
            {
                var product = new Product
                {
                    Name = animal.Type + " Product",
                    Price = 20,
                    ProducedAt = now,
                    AnimalId = animal.Id
                };

                _context.Products.Add(product);
                animal.LastProducedAt = now;
            }
        }

        _context.SaveChanges();
    }
}
