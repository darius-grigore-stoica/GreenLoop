using GreenLoopAPI.Application.Services;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;
using GreenLoopAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GreenLoopAPI.Infrastructure.Repositories;

public class UserRepository(GreenLoopDbContext context, ILogger<AuthService> logger) : IUserRepository
{
    protected readonly GreenLoopDbContext _context = context;
    protected readonly ILogger<AuthService> _logger = logger;

    public async Task<User?> GetByEmailAsync(string email)
    {
        try
        {
            _logger.LogInformation("Getting user by {email}", email);
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
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
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
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
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        } catch(Exception e)
        {
            _logger.LogError(e, "Error getting user by id");
            return null;
        }
    }

    public Task<IEnumerable<User?>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<User?> AddAsync(User entity)
    {
        try
        {
            _logger.LogInformation("Adding user");
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
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