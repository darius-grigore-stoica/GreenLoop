using GreenLoopAPI.Application.Services;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;
using GreenLoopAPI.Infrastructure.Data;

namespace GreenLoopAPI.Infrastructure.Repositories;

public class EventRepository(GreenLoopDbContext context, ILogger<AuthService> logger) : IEventRepository
{
    protected readonly GreenLoopDbContext _context = context;
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
            IEnumerable<Event?> events = _context.Events;
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