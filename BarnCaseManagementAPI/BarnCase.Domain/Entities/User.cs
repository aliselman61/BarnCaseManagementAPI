namespace BarnCase.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Role { get; set; } = "User";

    public decimal Balance { get; set; }

    public ICollection<Farm> Farms { get; set; } = new List<Farm>();
}