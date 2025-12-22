namespace BarnCase.Domain.Entities;

public class Animal
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int LifeTimeInDays { get; set; }

    public int ProductionIntervalInHours { get; set; }

    public int FarmId { get; set; }
    public Farm Farm { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
