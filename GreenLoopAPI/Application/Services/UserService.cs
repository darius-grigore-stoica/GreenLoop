using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;

namespace GreenLoopAPI.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<UserDTO?> GetByUsernameAsync(string username)
    {
        var user = await userRepository.GetByUsernameAsync(username);
        return new UserDTO(user.Email, user.Username);
    }

    public async Task<UserDTO?> GetByEmailAsync(string email)
    {
        var user = await userRepository.GetByEmailAsync(email);
        return new UserDTO(user.Email, user.Username);
    }

    public async Task<UserDTO?> RegisterAsync(string email, string username, string password)
    {
        User u = new User(email, username, password);
        var user = await userRepository.RegisterAsync(u, password);
        return new UserDTO(user.Email, user.Username);
    }

    public async Task<UserDTO?> LoginAsync(string email, string password)
    {
        var user = await userRepository.LoginAsync(email, password);
        return new UserDTO(user.Email, user.Username);
    }
}