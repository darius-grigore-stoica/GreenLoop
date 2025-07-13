using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace GreenLoopAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    
    public UsersController(IUserService userService, AuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }
    
    [HttpGet]
    public async Task<ActionResult<UserDTO>> GetByUsernameAsync(string username)
    {
        var user = await _userService.GetByUsernameAsync(username);
        return Ok(user);
    }
    
    [HttpGet]
    public async Task<ActionResult<UserDTO>> GetByEmailAsync(string email)
    {
        var user = await _userService.GetByEmailAsync(email);
        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDTO>> RegisterAsync([FromBody] RegisterDTO registerDto)
    {
        var user = await _authService.RegisterAsync(registerDto);
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> LoginAsync([FromBody] LoginDTO loginDto)
    {
        var result = await _authService.AuthenticateAsync(loginDto);

        if (!result.Success)
            return Unauthorized(result.Message);

        return Ok(new { token = result.Token });
    }
}