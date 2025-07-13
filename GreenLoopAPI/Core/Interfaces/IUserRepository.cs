using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Core.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUsernameAsync(string username);

}