using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Application.Services;
using GreenLoopAPI.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace GreenLoopAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsAttendanceController : ControllerBase
{
    private readonly IEventAttendanceService _eventAttendanceService;
    
    public EventsAttendanceController(IEventAttendanceService eventAttendanceService)
    {
        _eventAttendanceService = eventAttendanceService;
    }

    [Authorize]
    [HttpPost("{id}/attend")]
    public async Task<IActionResult> AttendEventAsync([FromBody] int eventId)
    {
        var value = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        if (value != null)
        {
            int userId = int.Parse(value);
            await _eventAttendanceService.AttendEventAsync(eventId, userId);
            return Ok();
        }

        return Unauthorized();
    }
}