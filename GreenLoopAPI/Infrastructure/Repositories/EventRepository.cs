using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;

namespace GreenLoopAPI.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    public Task<Event?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Event?>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Event?> AddAsync(Event entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Event entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Event entity)
    {
        throw new NotImplementedException();
    }
}