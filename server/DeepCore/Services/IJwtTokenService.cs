using DeepCore.DAL.Entities;

namespace DeepCore.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
