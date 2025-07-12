using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;

namespace GreenLoopAPI.Application.Services;

public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;
    public async Task<IEnumerable<Event>?> GetAllEventsAsync()
    {
        IEnumerable<Event> events = await _eventRepository.GetAllAsync();
        return events;
    }

    public async Task<Event?> GetEventByIdAsync(int id)
    {
        Event e = await _eventRepository.GetByIdAsync(id);
        return e;
    }

    public async void CreateEventAsync(Event newEvent)
    {
        await _eventRepository.AddAsync(newEvent);
    }
}