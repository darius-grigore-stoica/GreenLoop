using GreenLoopAPI.Application.Services;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;
using GreenLoopAPI.Infrastructure.Data;
using MongoDB.Driver;

namespace GreenLoopAPI.Infrastructure.Repositories;

public class EventRepository(IMongoCollection<Event> events, ILogger<AuthService> logger) : IEventRepository
{
    protected readonly IMongoCollection<Event> _events = events;
    protected readonly ILogger<AuthService> _logger = logger;
    public Task<Event?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Event?>> GetAllAsync()
    {
        try
        {
            _logger.LogInformation("Getting all users");
            var users = await _events.Find(u => true).ToListAsync();
            _logger.LogInformation("Retrieved {Count} users", users.Count);
            return users;
        } catch (Exception e)
        {
            _logger.LogError(e, "Error getting all users");
            return Enumerable.Empty<Event>();
        }
    }

    public async Task<Event?> AddAsync(Event entity)
    {
        try
        {
            _logger.LogInformation("Adding event with ID: {Id}", entity.Id);
            await _events.InsertOneAsync(entity);
            _logger.LogInformation("Event added successfully with ID: {Id}", entity.Id);
            return entity;
        } catch (Exception e)
        {
            _logger.LogError(e, "Error adding event with ID: {Id}", entity?.Id);
            return null;
        }
    }

    public Task<Event?> UpdateAsync(Event entity)
    {
        throw new NotImplementedException();
    }

    public Task<Event?> DeleteAsync(Event entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Event?>> GetByCategoryAsync(EventCategory category)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Event?>> GetByCreatorIdAsync(String createrUsername)
    {
        throw new NotImplementedException();
    }
}