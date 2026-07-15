using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserAsync(string username, string passwordHash, CancellationToken cancellationToken);
    }
}
