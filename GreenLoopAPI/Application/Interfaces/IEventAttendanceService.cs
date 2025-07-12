using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.Interfaces;

public interface IEventAttendanceService
{
    Task<bool> AttendEventAsync(int eventId, int userId);
    Task<IEnumerable<User>?> GetAttendeesForEventAsync(int eventId);
}