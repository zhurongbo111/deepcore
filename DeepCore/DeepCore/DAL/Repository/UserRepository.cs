using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeepCore.DAL.Repository
{
    public class UserRepository : AbstractEFRepository<User>, IUserRepository
    {
        public UserRepository(DeepCoreDbContext context) : base(context)
        {
        }

        public Task<User?> GetUserAsync(string username, CancellationToken cancellationToken)
        {
            return this.Table.Where(u => u.UserName == username)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public Task<User?> GetUserAsync(Guid publicUserId, CancellationToken cancellationToken)
        {
            return this.Table.Where(u => u.PublicUserId == publicUserId)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
