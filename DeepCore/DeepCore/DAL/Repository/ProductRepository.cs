using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeepCore.DAL.Repository
{
    public class ProductRepository : AbstractEFRepository<Product>, IProductRepository
    {
        public ProductRepository(DeepCoreDbContext context) : base(context)
        {
        }

        public Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken)
        {
            return TableAsNoTracking.AnyAsync(p => p.Code == code, cancellationToken);
        }

        public Task<Product?> GetByCodeAsync(string code, CancellationToken cancellationToken)
        {
            return Table.FirstOrDefaultAsync(p => p.Code == code, cancellationToken);
        }

        public Task<Product?> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return Table.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<(IEnumerable<Product> products, long total)> GetPagedAsync(int pageIndex, int pageSize, string? keyword, int? status, CancellationToken cancellationToken)
        {
            var query = TableAsNoTracking;
            if(status != null)
            {
                query = query.Where(p => p.Status == status.Value);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Code.Contains(keyword) || p.Name.Contains(keyword));
            }

            (var items, var total) = await query.ToPagedListAsync(pageIndex, pageSize, cancellationToken);

            return (items, total);
        }
    }
}
