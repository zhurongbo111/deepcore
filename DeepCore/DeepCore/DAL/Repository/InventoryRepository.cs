using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeepCore.DAL.Repository
{
    public class InventoryRepository : AbstractEFRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(DeepCoreDbContext context) : base(context)
        {
        }

        public Task<Inventory?> GetByProductIdAsync(long productId, CancellationToken cancellationToken)
        {
            return Table.Include(i => i.Product).FirstOrDefaultAsync(i => i.ProductId == productId, cancellationToken);
        }

        public async Task<(IEnumerable<Inventory> items, long total)> GetPagedAsync(int pageIndex, int pageSize, string? name, string? code, CancellationToken cancellationToken)
        {
            var query = TableAsNoTracking.Include(i => i.Product).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(i => i.Product != null && i.Product.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(code))
            {
                query = query.Where(i => i.Product != null && i.Product.Code.Contains(code));
            }

            (var items, var total) = await query.ToPagedListAsync(pageIndex, pageSize, cancellationToken);

            return (items, total);
        }
    }
}
