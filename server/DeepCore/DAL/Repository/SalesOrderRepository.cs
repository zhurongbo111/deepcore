using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeepCore.DAL.Repository
{
    public class SalesOrderRepository : AbstractEFRepository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(DeepCoreDbContext context) : base(context)
        {
        }

        public Task<SalesOrder?> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return Table.Include(s => s.Items).ThenInclude(i => i.Product).Include(s => s.Customer).FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<(IEnumerable<SalesOrder> items, long total)> GetPagedAsync(int pageIndex, int pageSize, string? orderNumber, long? customerId, int? status, CancellationToken cancellationToken)
        {
            var query = TableAsNoTracking.Include(s => s.Customer).AsQueryable();

            if (!string.IsNullOrEmpty(orderNumber))
            {
                query = query.Where(s => s.OrderNo.Contains(orderNumber));
            }

            if (customerId != null)
            {
                query = query.Where(s => s.CustomerId == customerId.Value);
            }

            if (status != null)
            {
                query = query.Where(s => s.Status == (SalesOrderStatus)status.Value);
            }

            (var items, var total) = await query.ToPagedListAsync(pageIndex, pageSize, cancellationToken);

            return (items, total);
        }
    }
}
