namespace BarnCaseManagementAPI.Models;

public class CreateFarmDto
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
}
