using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenLoopAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService, IAuthService authService) : ControllerBase
{
    [HttpGet("username/{username}")]
    public async Task<ActionResult<UserDTO>> GetByUsernameAsync(string username)
    {
        try
        {
            var user = await userService.GetByUsernameAsync(username);
            return Ok(user);
        } catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("email/{email}")]
    public async Task<ActionResult<UserDTO>> GetByEmailAsync(string email)
    {
        try
        {
            var user = await userService.GetByEmailAsync(email);
            return Ok(user);
        } catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResult>> RegisterAsync([FromBody] RegisterDTO registerDto)
    {
        try
        {
            var auth = await authService.RegisterAsync(registerDto);
            if (auth is { Success: false })
                return BadRequest(auth.Message);
            return Ok(auth);
        } catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> LoginAsync([FromBody] LoginDTO loginDto)
    {
        try
        {
            var result = await authService.AuthenticateAsync(loginDto);

            if (!result.Success)
                return Unauthorized(result.Message);

            return Ok(new { token = result.Token });
        } catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}