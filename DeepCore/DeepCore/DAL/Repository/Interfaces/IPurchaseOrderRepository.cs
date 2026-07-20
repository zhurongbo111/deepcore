using DeepCore.DAL.Entities;
using System;

namespace DeepCore.DAL.Repository.Interfaces
{
    public interface IPurchaseOrderRepository : IRepository<PurchaseOrder>
    {
        Task<PurchaseOrder?> GetByIdAsync(long id, CancellationToken cancellationToken);

        Task<(IEnumerable<PurchaseOrder> items, long total)> GetPagedAsync(int pageIndex, int pageSize, string? orderNumber, long? supplierId, int? status, DateTime? from, DateTime? to, CancellationToken cancellationToken);
    }
}
