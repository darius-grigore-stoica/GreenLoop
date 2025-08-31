using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Core.Interfaces;

public interface IEventRepository : IRepository<Event>
{
    public Task<IEnumerable<Event?>> GetByCategoryAsync(EventCategory category);
    
    public Task<IEnumerable<Event?>> GetByCreatorIdAsync(String createrUsername);
}