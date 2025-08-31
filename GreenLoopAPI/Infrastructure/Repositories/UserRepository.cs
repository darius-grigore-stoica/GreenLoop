using GreenLoopAPI.Application.Services;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;
using GreenLoopAPI.Infrastructure.Data;
using MongoDB.Driver;

namespace GreenLoopAPI.Infrastructure.Repositories;

public class UserRepository(IMongoCollection<User> users, ILogger<UserRepository> logger) : IUserRepository
{
    protected readonly IMongoCollection<User> _users = users;
    protected readonly ILogger<UserRepository> _logger = logger;

    public async Task<User?> GetByEmailAsync(string email)
    {
        try
        {
            _logger.LogInformation("Getting user by email: {Email}", email);
            return await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
        } catch (Exception e)
        {
            _logger.LogError(e, "Error getting user by email: {Email}", email);
            return null;
        }
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        try
        {
            _logger.LogInformation("Getting user by username: {Username}", username);
            return await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
        } catch (Exception e)
        {
            _logger.LogError(e, "Error getting user by username: {Username}", username);
            return null;
        }
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        try
        {
            _logger.LogInformation("Getting user by ID: {Id}", id);
            return await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
        } catch (Exception e)
        {
            _logger.LogError(e, "Error getting user by ID: {Id}", id);
            return null;
        }
    }

    public async Task<IEnumerable<User?>> GetAllAsync()
    {
        try
        {
            _logger.LogInformation("Getting all users");
            var users = await _users.Find(u => true).ToListAsync();
            _logger.LogInformation("Retrieved {Count} users", users.Count);
            return users;
        } catch (Exception e)
        {
            _logger.LogError(e, "Error getting all users");
            return Enumerable.Empty<User>();
        }
    }

    public async Task<User?> AddAsync(User entity)
    {
        try
        {
            _logger.LogInformation("Adding user with ID: {Id}", entity.Id);
            await _users.InsertOneAsync(entity);
            _logger.LogInformation("User added successfully with ID: {Id}", entity.Id);
            return entity;
        } catch (Exception e)
        {
            _logger.LogError(e, "Error adding user with ID: {Id}", entity?.Id);
            return null;
        }
    }

    public Task<User?> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User?> DeleteAsync(User entity)
    {
        throw new NotImplementedException();
    }
}