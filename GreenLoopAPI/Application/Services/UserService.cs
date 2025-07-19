using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Core.Interfaces;

namespace GreenLoopAPI.Application.Services;

public class UserService(IUserRepository userRepository, ILogger<AuthService> logger) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ILogger<AuthService> _logger = logger;
    
    public async Task<UserDTO?> GetByUsernameAsync(string username)
    {
        try {
            _logger.LogInformation("Getting user by username");
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null)
            {
                _logger.LogInformation("User not found");
                throw new Exception("User not found");
            }

            _logger.LogInformation("User found");
            return new UserDTO(user.Email, user.Username);
        }
        catch (Exception e) {
            _logger.LogError(e, "Error getting user by username");
            return null;
        }
}

    public async Task<UserDTO?> GetByEmailAsync(string email)
    {
        try
        {
            _logger.LogInformation("Getting user by email");
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation("User not found");
                throw new Exception("User not found");
            }

            _logger.LogInformation("User found");
            return new UserDTO(user.Email, user.Username);
        } catch(Exception e)
        {
            _logger.LogError(e, "Error getting user by email");
            return null;
        }
    }
}