using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.Interfaces;

public interface IUserService
{
    public Task<UserDTO?> GetByUsernameAsync(string username);
    
    public Task<UserDTO?> GetByEmailAsync(string email);
    public Task<UserDTO?> RegisterAsync(string email, string username, string password);
    public Task<UserDTO?> LoginAsync(string email, string password);
    Task<Boolean> Logout(int userId);
}