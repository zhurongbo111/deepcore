using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserAsync(string username, CancellationToken cancellationToken);

        Task<User?> GetUserAsync(Guid publicUserId, CancellationToken cancellationToken);
    }
}
