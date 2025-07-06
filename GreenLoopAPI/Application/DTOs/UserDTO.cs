namespace GreenLoopAPI.Application.DTOs;

public class UserDTO
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;

    public UserDTO(String email, String username)
    {
        Email = email;
        Username = username;
    }
}