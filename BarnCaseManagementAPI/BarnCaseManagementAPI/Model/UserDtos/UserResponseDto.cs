namespace BarnCaseManagementAPI.Models;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public decimal Balance { get; set; }
    public string Role { get; set; } = null!;
}
