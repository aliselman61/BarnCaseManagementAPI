namespace BarnCaseManagementAPI.Models;

public class BuyAnimalDto
{
    public Guid FarmId { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public int Age { get; set; }
    public decimal Price { get; set; }
}
