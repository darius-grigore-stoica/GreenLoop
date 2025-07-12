using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.Interfaces;

public interface IEventService
{
    Task<IEnumerable<Event>?> GetAllEventsAsync();
    
    Task<Event?> GetEventByIdAsync(int id);
    
    Task<Boolean> CreateEventAsync(Event newEvent);
}