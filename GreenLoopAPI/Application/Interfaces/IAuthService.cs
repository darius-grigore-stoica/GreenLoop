using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.Interfaces;

public interface IAuthService
{
    public Task<AuthResult> AuthenticateAsync(LoginDTO loginDto);
    public Task<AuthResult?> LoginAsync(LoginDTO loginDto);

    public Task<AuthResult?> RegisterAsync(RegisterDTO loginDto);
}