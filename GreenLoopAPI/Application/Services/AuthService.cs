using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GreenLoopAPI.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    
    public AuthService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResult> AuthenticateAsync(LoginDTO loginDto)
    {
        var user = await _userRepository.GetByEmailAsync(loginDto.Email);
        if (user == null || user.PasswordHash != loginDto.Password)
            return new AuthResult(false, "", "Invalid credentials");

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthResult(true, token, "");
    }
    public async Task<AuthResult?> LoginAsync(LoginDTO loginDto)
    {
        var user = await _userRepository.GetByEmailAsync(loginDto.Email);
        if (user == null) throw new Exception("User not found");

        bool validPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
        if (!validPassword) throw new Exception("Invalid credentials");

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthResult(true, token, "");
    }

    public async Task<AuthResult?> RegisterAsync(RegisterDTO registerDto)
    {
        var user = _userRepository.GetByEmailAsync(registerDto.Email);
        if(user != null) throw new Exception("User already exists");

        var passwordHash = PasswordHash(registerDto.Password);

        var newUser = new User(registerDto.Email, passwordHash, registerDto.Username);
        
        await _userRepository.AddAsync(newUser);
        
        var token = _jwtTokenGenerator.GenerateToken(newUser);
        return new AuthResult(true, token, "");
    }

    public string PasswordHash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}