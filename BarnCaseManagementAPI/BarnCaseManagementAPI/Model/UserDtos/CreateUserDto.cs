namespace BarnCaseManagementAPI.Models;

public class CreateUserDto
{
    public string Username { get; set; } = null!;
    public decimal Balance { get; set; }
}
