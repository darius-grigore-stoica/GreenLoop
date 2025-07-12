using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Core.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}