using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;

namespace GreenLoopAPI.Infrastructure.Repositories;

public class EventAttandenceRepository : IEventAttendanceRepository
{
    public Task<EventAttendance> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EventAttendance?>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EventAttendance?> AddAsync(EventAttendance entity)
    {
        throw new NotImplementedException();
    }

    public void Update(EventAttendance entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(EventAttendance entity)
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