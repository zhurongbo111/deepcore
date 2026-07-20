using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Get a product by id
        /// </summary>
        Task<Product?> GetByIdAsync(long id, CancellationToken cancellationToken);

        /// <summary>
        /// Get a product by its code
        /// </summary>
        Task<Product?> GetByCodeAsync(string code, CancellationToken cancellationToken);

        /// <summary>
        /// Check whether a product code already exists
        /// </summary>
        Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken);

        /// <summary>
        /// Get paged list of products with optional keyword search
        /// Returns items and total count
        /// </summary>
        Task<(IEnumerable<Product> products, long total)> GetPagedAsync(int pageIndex, int pageSize, string? keyword, int? status, CancellationToken cancellationToken);
    }
}
