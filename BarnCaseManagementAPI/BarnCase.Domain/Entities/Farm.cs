namespace BarnCase.Domain.Entities;

public class Farm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public ICollection<Animal> Animals { get; set; } = new List<Animal>();
}
