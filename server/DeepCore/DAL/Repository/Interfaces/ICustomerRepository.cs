using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// Get a customer by id
        /// </summary>
        Task<Customer?> GetByIdAsync(long id, CancellationToken cancellationToken);

        /// <summary>
        /// Get paged list of customers with optional filters
        /// Returns items and total count
        /// </summary>
        Task<(IEnumerable<Customer> customers, long total)> GetPagedAsync(int pageIndex, int pageSize, string? name, string? contact, string? phone, int? status, CancellationToken cancellationToken);
    }
}
