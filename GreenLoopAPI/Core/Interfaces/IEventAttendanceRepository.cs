using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Core.Interfaces;

public interface IEventAttendanceRepository : IRepository<EventAttandance>
{
    Task<User?> GetAttendeesForEventAsync(int eventId);
    Task<bool> AttendEventAsync(int eventId);
}