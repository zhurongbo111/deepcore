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

        public Task<User?> GetUserAsync(string username, string passwordHash, CancellationToken cancellationToken)
        {
            return this.Table.Where(u => u.UserName == username && u.PasswordHash == passwordHash)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
