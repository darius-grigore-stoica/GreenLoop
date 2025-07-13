using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace GreenLoopAPI.Application.Services;

public class UserService(IUserRepository _userRepository) : IUserService
{
    public async Task<UserDTO?> GetByUsernameAsync(string username)
    {
        var user = await _userRepository.GetByUsernameAsync(username);
        return new UserDTO(user.Email, user.Username);
    }

    public async Task<UserDTO?> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        return new UserDTO(user.Email, user.Username);
    }
}