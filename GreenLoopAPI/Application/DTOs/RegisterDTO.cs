namespace GreenLoopAPI.Application.DTOs;

public class RegisterDTO
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}