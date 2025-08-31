using GreenLoopAPI.Application.DTOs;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenLoopAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<EventsController> _logger;

    public EventsController(
        IEventRepository eventRepository, 
        IUserRepository userRepository,
        ILogger<EventsController> logger)
    {
        _eventRepository = eventRepository;
        _userRepository = userRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
    {
        try
        {
            var events = await _eventRepository.GetAllAsync();
            return Ok(events);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error retrieving all events");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        try
        {
            var eventItem = await _eventRepository.GetByIdAsync(id);
            if (eventItem == null)
            {
                return NotFound($"Event with ID {id} not found");
            }
            return Ok(eventItem);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error retrieving event with ID: {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("category/{category}")]
    public async Task<ActionResult<IEnumerable<Event>>> GetEventsByCategory(EventCategory category)
    {
        try
        {
            var events = await _eventRepository.GetByCategoryAsync(category);
            return Ok(events);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error retrieving events by category: {Category}", category);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("creator/{createrUsername}")]
    public async Task<ActionResult<IEnumerable<Event>>> GetEventsByCreator(String createrUsername)
    {
        try
        {
            var events = await _eventRepository.GetByCreatorIdAsync(createrUsername);
            return Ok(events);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error retrieving events by creator: {CreatorId}", createrUsername);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Event>> CreateEvent([FromBody] CreateEventRequest request)
    {
        try
        {
            var creator = await _userRepository.GetByIdAsync(request.CreatorId);
            if (creator == null)
            {
                return BadRequest("Invalid creator ID");
            }

            var eventItem = new Event(
                request.Title,
                request.Description,
                request.DateTime,
                request.Location,
                request.Category,
                creator
            );

            var createdEvent = await _eventRepository.AddAsync(eventItem);
            if (createdEvent == null)
            {
                return BadRequest("Failed to create event");
            }

            return CreatedAtAction(nameof(GetEvent), new { id = createdEvent.Id }, createdEvent);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error creating event");
            return StatusCode(500, "Internal server error");
        }
    }
}



