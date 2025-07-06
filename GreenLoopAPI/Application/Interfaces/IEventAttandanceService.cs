using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.Interfaces;

public interface IEventAttandanceService
{
    Task<bool> AttendEventAsync(int eventId);
    Task<User?> GetAttendeesForEventAsync(int eventId);
}