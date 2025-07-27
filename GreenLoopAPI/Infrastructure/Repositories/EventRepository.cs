using GreenLoopAPI.Application.Services;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;
using GreenLoopAPI.Infrastructure.Data;
using MongoDB.Driver;

namespace GreenLoopAPI.Infrastructure.Repositories;

public class EventRepository(IMongoCollection<Event> events, ILogger<AuthService> logger) : IEventRepository
{
    protected readonly IMongoCollection<Event> _context = events;
    protected readonly ILogger<AuthService> _logger = logger;
    public Task<Event?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Event?>> GetAllAsync()
    {
        try
        {
            _logger.LogInformation("Getting all events");
            IEnumerable<Event?> events = _context.Find(e => true).ToList();
            _logger.LogInformation("Events retrieved");
            return Task.FromResult(events);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting all events");
            return null;
        }
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