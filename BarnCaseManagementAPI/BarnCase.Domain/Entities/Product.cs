namespace BarnCase.Domain.Entities;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime ProducedAt { get; set; }

    public int AnimalId { get; set; }
    public Animal Animal { get; set; } = null!;
}
