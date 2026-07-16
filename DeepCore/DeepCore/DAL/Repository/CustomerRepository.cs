using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DeepCore.DAL.Repository
{
    public class CustomerRepository : AbstractEFRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DeepCoreDbContext context) : base(context)
        {
        }

        public Task<Customer?> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return Table.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<(IEnumerable<Customer> customers, long total)> GetPagedAsync(int pageIndex, int pageSize, string? name, string? contact, string? phone, int? status, CancellationToken cancellationToken)
        {
            var query = TableAsNoTracking;

            if (status != null)
            {
                query = query.Where(c => c.Status == status.Value);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(contact))
            {
                query = query.Where(c => c.ContactName.Contains(contact));
            }

            if (!string.IsNullOrEmpty(phone))
            {
                query = query.Where(c => c.Phone.Contains(phone));
            }

            (var items, var total) = await query.ToPagedListAsync(pageSize, pageIndex, cancellationToken);

            return (items, total);
        }
    }
}
