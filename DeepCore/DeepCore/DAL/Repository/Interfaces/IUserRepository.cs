using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserAsync(string username, CancellationToken cancellationToken);

        Task<User?> GetUserAsync(Guid publicUserId, CancellationToken cancellationToken);

        /// <summary>
        /// Get a user by id
        /// </summary>
        Task<User?> GetByIdAsync(long id, CancellationToken cancellationToken);

        /// <summary>
        /// Get paged list of users with optional filters
        /// Returns items and total count
        /// </summary>
        Task<(IEnumerable<User> users, long total)> GetPagedAsync(int pageIndex, int pageSize, string? name, string? phone, int? status, CancellationToken cancellationToken);
    }
}
