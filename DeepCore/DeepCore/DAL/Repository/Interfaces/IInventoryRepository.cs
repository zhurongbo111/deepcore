using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository.Interfaces
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<Inventory?> GetByProductIdAsync(long productId, CancellationToken cancellationToken);

        Task<(IEnumerable<Inventory> items, long total)> GetPagedAsync(int pageIndex, int pageSize, string? name, string? code, CancellationToken cancellationToken);
    }
}
