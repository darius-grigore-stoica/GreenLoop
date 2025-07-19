using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;

namespace GreenLoopAPI.Application.Services;

public class EventService(IEventRepository eventRepository, ILogger<Event> logger) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly ILogger<Event> _logger = logger;
    public async Task<IEnumerable<Event>?> GetAllEventsAsync()
    {
        try
        {
            _logger.LogInformation("Getting all events");
            IEnumerable<Event?> events = await _eventRepository.GetAllAsync();
            _logger.LogInformation("Events retrieved");
            return events;
        } catch(Exception e)
        {
            _logger.LogError(e, "Error getting all events");
            return null;
        }
    }

    public async Task<Event?> GetEventByIdAsync(int id)
    {
        try
        {
            _logger.LogInformation("Getting event by id {id}", id);
            Event? e = await _eventRepository.GetByIdAsync(id);
            _logger.LogInformation("Event retrieved");
            return e;
        } catch(Exception e)
        {
            _logger.LogError(e, "Error getting event by id");
            return null;
        }
    }

    public async Task<Boolean> CreateEventAsync(Event newEvent)
    {
        try
        {
            await _eventRepository.AddAsync(newEvent);
            return true;
        } catch(Exception e)
        {
            return false;
        }
    }
}