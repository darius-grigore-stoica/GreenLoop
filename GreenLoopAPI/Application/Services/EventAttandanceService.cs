using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.Services;

public class EventAttandanceService : IEventAttandanceService
{
    public async Task AddAsync(EventAttandance entity)
    {
        throw new NotImplementedException();
    }

    public async void Update(EventAttandance entity)
    {
        throw new NotImplementedException();
    }

    public async void Delete(EventAttandance entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AttendEventAsync(int eventId)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetAttendeesForEventAsync(int eventId)
    {
        throw new NotImplementedException();
    }
}