using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DeepCore.DAL.Repository
{
    public class SupplierRepository : AbstractEFRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(DeepCoreDbContext context) : base(context)
        {
        }

        public Task<Supplier?> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return Table.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<(IEnumerable<Supplier> suppliers, long total)> GetPagedAsync(int pageIndex, int pageSize, string? name, string? contact, string? phone, int? status, CancellationToken cancellationToken)
        {
            var query = TableAsNoTracking;

            if (status != null)
            {
                query = query.Where(s => s.Status == status.Value);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(contact))
            {
                query = query.Where(s => s.ContactName.Contains(contact));
            }

            if (!string.IsNullOrEmpty(phone))
            {
                query = query.Where(s => s.Phone.Contains(phone));
            }

            (var items, var total) = await query.ToPagedListAsync(pageIndex, pageSize, cancellationToken);

            return (items, total);
        }
    }
}
