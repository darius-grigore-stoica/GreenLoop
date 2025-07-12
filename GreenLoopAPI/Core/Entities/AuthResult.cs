namespace GreenLoopAPI.Application.DTOs;

public class AuthResult
{
    public bool Success { get; set; }
    public string Token { get; set; } = null!;
    public string Message { get; set; } = null!;
    
    public AuthResult(bool success, string token, string message)
    {
        Success = success;
        Token = token;
        Message = message;
    }
}