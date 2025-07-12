using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;

namespace GreenLoopAPI.Infrastructure.Repositories;

public class EventAttandenceRepository : IEventAttendanceRepository
{
    public Task<EventAttandance> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EventAttandance>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(EventAttandance entity)
    {
        throw new NotImplementedException();
    }

    public void Update(EventAttandance entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(EventAttandance entity)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetAttendeesForEventAsync(int eventId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AttendEventAsync(int eventId)
    {
        throw new NotImplementedException();
    }
}