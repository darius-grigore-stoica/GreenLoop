using GreenLoopAPI.Application.Services;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;
using GreenLoopAPI.Infrastructure.Data;
using MongoDB.Driver;

namespace GreenLoopAPI.Infrastructure.Repositories;

public class UserRepository(IMongoCollection<User> users, ILogger<AuthService> logger) : IUserRepository
{
    private readonly IMongoCollection<User> _users = users;
    protected readonly ILogger<AuthService> _logger = logger;

    public async Task<User?> GetByEmailAsync(string email)
    {
        try
        {
            _logger.LogInformation("Getting user by {email}", email);
            return await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
        } catch(Exception e)
        {
            _logger.LogError(e, "Error getting user by email");
            return null;
        }
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        try
        {
            _logger.LogInformation("Getting user by {username}", username);
            return await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
        } catch(Exception e)
        {
            _logger.LogError(e, "Error getting user by username");
            return null;
        }
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        try
        {
            _logger.LogInformation("Getting user by {id}", id);
            return await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
        } catch(Exception e)
        {
            _logger.LogError(e, "Error getting user by id");
            return null;
        }
    }

    public Task<IEnumerable<User?>> GetAllAsync()
    {
        try
        {
            _logger.LogInformation("Getting all users");
            IEnumerable<User?> users = _users.Find(u => true).ToList();
            _logger.LogInformation("Users retrieved");
            return Task.FromResult(users);
        } catch(Exception e)
        {
            _logger.LogError(e, "Error getting all users");
            return null;
        }
    }

    public async Task<User?> AddAsync(User entity)
    {
        try
        {
            _logger.LogInformation("Adding user");
            await _users.InsertOneAsync(entity);
            _logger.LogInformation("User added");
            return entity;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error adding user");
            return null;
        }
    }

    public void Update(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(User entity)
    {
        throw new NotImplementedException();
    }
}