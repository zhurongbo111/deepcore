using DeepCore.DAL.Entities;
using System;

namespace DeepCore.DAL.Repository.Interfaces
{
    public interface ISalesOrderRepository : IRepository<SalesOrder>
    {
        Task<SalesOrder?> GetByIdAsync(long id, CancellationToken cancellationToken);

        Task<(IEnumerable<SalesOrder> items, long total)> GetPagedAsync(int pageIndex, int pageSize, string? orderNumber, long? customerId, int? status, CancellationToken cancellationToken);
    }
}
