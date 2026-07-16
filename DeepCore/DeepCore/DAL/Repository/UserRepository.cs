using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public Task<User?> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return Table.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<(IEnumerable<User> users, long total)> GetPagedAsync(int pageIndex, int pageSize, string? name, string? phone, int? status, CancellationToken cancellationToken)
        {
            var query = TableAsNoTracking;

            if (status != null)
            {
                query = query.Where(u => u.Status == status.Value);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(u => u.UserName.Contains(name) || (u.RealName != null && u.RealName.Contains(name)));
            }

            if (!string.IsNullOrEmpty(phone))
            {
                query = query.Where(u => u.Phone.Contains(phone));
            }

            (var items, var total) = await query.ToPagedListAsync(pageSize, pageIndex, cancellationToken);

            return (items, total);
        }
    }
}
