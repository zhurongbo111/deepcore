using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        /// <summary>
        /// Get a supplier by id
        /// </summary>
        Task<Supplier?> GetByIdAsync(long id, CancellationToken cancellationToken);

        /// <summary>
        /// Get paged list of suppliers with optional filters
        /// Returns items and total count
        /// </summary>
        Task<(IEnumerable<Supplier> suppliers, long total)> GetPagedAsync(int pageIndex, int pageSize, string? name, string? contact, string? phone, int? status, CancellationToken cancellationToken);
    }
}
