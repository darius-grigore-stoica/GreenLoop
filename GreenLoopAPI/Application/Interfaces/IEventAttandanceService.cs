using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.Interfaces;

public interface IEventAttandanceService
{
    Task<bool> AttendEventAsync(int eventId, int userId);
    Task<IEnumerable<User>?> GetAttendeesForEventAsync(int eventId);
}