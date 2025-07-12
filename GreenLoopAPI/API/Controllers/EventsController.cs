using System.IdentityModel.Tokens.Jwt;
using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenLoopAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;
    private readonly IUserRepository _userRepository;
    
    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllEventsAsync()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventByIdAsync(int id)
    {
        var eventById = await _eventService.GetEventByIdAsync(id);
        return Ok(eventById);
    }

    
    [Authorize]
    [HttpPost("creates")]
    public async Task<IActionResult> CreateEventAsync([FromBody] CreateEventRequest request)
    {
        var value = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value; // TODO: check it shouldn't be CLAIMS.Name
        if (value != null)
        {
            int userId = int.Parse(value);
            var newEvent = new Event(request.Title, request.Description, request.StartDate, request.Location, request.Category, await _userRepository.GetByIdAsync(userId));
            await _eventService.CreateEventAsync(newEvent);
            return Ok();
        }
        return Unauthorized();
    }
}