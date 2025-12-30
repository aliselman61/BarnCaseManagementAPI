namespace BarnCase.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime ProducedAt { get; set; }

    public Guid AnimalId { get; set; }
    public Animal Animal { get; set; } = null!;
}
