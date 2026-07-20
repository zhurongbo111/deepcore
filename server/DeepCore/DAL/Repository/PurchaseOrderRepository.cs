using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeepCore.DAL.Repository
{
    public class PurchaseOrderRepository : AbstractEFRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(DeepCoreDbContext context) : base(context)
        {
        }

        public Task<PurchaseOrder?> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return Table.Include(p => p.Items).ThenInclude(i => i.Product).Include(p => p.Supplier).FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<(IEnumerable<PurchaseOrder> items, long total)> GetPagedAsync(int pageIndex, int pageSize, string? orderNumber, long? supplierId, int? status, DateTime? from, DateTime? to, CancellationToken cancellationToken)
        {
            var query = TableAsNoTracking.Include(p => p.Supplier).AsQueryable();

            if (!string.IsNullOrEmpty(orderNumber))
            {
                query = query.Where(p => p.OrderNo.Contains(orderNumber));
            }

            if (supplierId != null)
            {
                query = query.Where(p => p.SupplierId == supplierId.Value);
            }

            if (status != null)
            {
                query = query.Where(p => p.Status == (PurchaseOrderStatus)status.Value);
            }

            if (from != null)
            {
                query = query.Where(p => p.OrderDate >= from.Value);
            }

            if (to != null)
            {
                query = query.Where(p => p.OrderDate <= to.Value);
            }

            (var items, var total) = await query.ToPagedListAsync(pageIndex, pageSize, cancellationToken);

            return (items, total);
        }
    }
}
