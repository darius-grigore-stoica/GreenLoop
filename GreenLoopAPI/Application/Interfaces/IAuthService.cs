using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.Interfaces;

public interface IAuthService
{
    public Task<AuthResult> AuthenticateAsync(string email, string password);
}