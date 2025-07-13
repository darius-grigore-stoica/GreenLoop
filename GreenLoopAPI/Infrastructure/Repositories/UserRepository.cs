using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;
using GreenLoopAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GreenLoopAPI.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    protected readonly GreenLoopDbContext _context;
    public UserRepository(GreenLoopDbContext context)
    {
        _context = context;
    }
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public Task<IEnumerable<User?>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(User entity)
    {
        throw new NotImplementedException();
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