using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.Services;

public class EventAttendanceService : IEventAttandanceService
{
    public Task<bool> AttendEventAsync(int eventId)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetAttendeesForEventAsync(int eventId)
    {
        throw new NotImplementedException();
    }
}