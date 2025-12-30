using BarnCase.Domain.Entities;

public class Animal
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public int Age { get; set; }
    public decimal Price { get; set; }

    public DateTime LastProducedAt { get; set; }
    public int ProductionIntervalInMinutes { get; set; }

    public Guid FarmId { get; set; }
    public Farm Farm { get; set; } = null!;
}
