using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Application.Interfaces;
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
    
    public UsersController(IUserService userService)
    {
        _userService = userService;
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
    public async Task<ActionResult<UserDTO>> RegisterAsync(string email, string username, string password)
    {
        var user = await _userService.RegisterAsync(email, username, password);
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> LoginAsync([FromBody] LoginDTO loginDto)
    {
        var result = await _authService.AuthenticateAsync(loginDto.Email, loginDto.Password);

        if (!result.Success)
            return Unauthorized(result.Message);

        return Ok(new { token = result.Token });
    }
    
    [Authorize]
    [HttpPost("logout")]
    public async Task<ActionResult> LogoutAsync()
    {
        var value = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        if (value != null)
        {
            int userId = int.Parse(value);
            await _userService.Logout(userId);
            return Ok();
        }
        return Unauthorized();
    }
}