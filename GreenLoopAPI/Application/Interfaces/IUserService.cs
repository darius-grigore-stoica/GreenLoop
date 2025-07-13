using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.Interfaces;

public interface IUserService
{
    public Task<UserDTO?> GetByUsernameAsync(string username);
    
    public Task<UserDTO?> GetByEmailAsync(string email);
}