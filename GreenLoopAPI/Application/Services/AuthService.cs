using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;
namespace GreenLoopAPI.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ILogger<AuthService> _logger;
    
    public AuthService(IUserRepository userRepository, 
        IJwtTokenGenerator jwtTokenGenerator,
        ILogger<AuthService> logger)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _logger = logger;
    }

    public async Task<AuthResult> AuthenticateAsync(LoginDTO loginDto)
    {
        try
        {
            _logger.LogInformation("Authenticating user with email {loginDtO.Email} starting...", loginDto.Email);
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            _logger.LogInformation("User authenticated");
            if (user == null || user.PasswordHash != loginDto.Password)
            {
                _logger.LogInformation("Invalid credentials");
                return new AuthResult(false, "", "Invalid credentials");
            }

            _logger.LogInformation("Generating token...");
            var token = _jwtTokenGenerator.GenerateToken(user);
            _logger.LogInformation("Token generated");
            return new AuthResult(true, token, "");
        } catch(Exception e)
        {
            _logger.LogError(e, "Error authenticating user");
            return new AuthResult(false, "", "Error authenticating user");
        }
    }
    public async Task<AuthResult?> LoginAsync(LoginDTO loginDto)
    {
        try
        {
            _logger.LogInformation("Loging in user with email {loginDtO.Email} starting...", loginDto.Email);
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            _logger.LogInformation("User logged in");

            if (user == null) throw new Exception("User not found");

            _logger.LogInformation("Validating password...");
            bool validPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
            if (!validPassword) throw new Exception("Invalid credentials");
            _logger.LogInformation("Password validated");

            _logger.LogInformation("Generating token...");
            var token = _jwtTokenGenerator.GenerateToken(user);
            _logger.LogInformation("Token generated");
            return new AuthResult(true, token, "");
        } catch(Exception e)
        {
            _logger.LogError(e, "Error logging in user");
            return new AuthResult(false, "", "Error logging in user");
        }
    }

    public async Task<AuthResult?> RegisterAsync(RegisterDTO registerDto)
    {
        try
        {
            _logger.LogInformation("Registering user with email {registerDto.Email} starting...", registerDto.Email);
            var user = _userRepository.GetByEmailAsync(registerDto.Email);
            if (user != null)
            {
                _logger.LogInformation("User already exists");
                throw new Exception("User already exists");
            }

            _logger.LogInformation("Hashing password...");
            var passwordHash = PasswordHash(registerDto.Password);

            _logger.LogInformation("Creating user...");
            var newUser = new User(registerDto.Email, passwordHash, registerDto.Username);

            _logger.LogInformation("Adding user to database...");
            await _userRepository.AddAsync(newUser);

            _logger.LogInformation("Generating token...");
            var token = _jwtTokenGenerator.GenerateToken(newUser);
            _logger.LogInformation("Token generated");
            return new AuthResult(true, token, "");
        } catch(Exception e)
        {
            _logger.LogError(e, "Error registering user");
            return new AuthResult(false, "", "Error registering user");
        }
    }

    public string PasswordHash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}