using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Core.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> RegisterAsync(User user, string password);
    Task<User?> LoginAsync(string email, string password);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUsernameAsync(string username);
    Task<bool> EmailExistsAsync(string email);
    Task<bool> UsernameExistsAsync(string username);
}