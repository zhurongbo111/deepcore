using Microsoft.EntityFrameworkCore;

namespace DeepCore.DAL.Repository
{
    public static class PagedQueryExtension
    {
        /// <summary>
        /// Get paged result.
        /// </summary>
        /// <typeparam name="TEntity">The entity to be queried.</typeparam>
        /// <param name="query">The linq query</param>
        /// <param name="pageNo">The page No, start from 1.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public static async Task<(List<TEntity> items, long total)> ToPagedListAsync<TEntity>(this IQueryable<TEntity> query, int pageNo, int pageSize, CancellationToken cancellationToken)
        {
            long totalCount = await query.LongCountAsync(cancellationToken);

            if (totalCount == 0)
            {
                return (new List<TEntity>(), 0);
            }

            if (pageSize == 0)
            {
                pageSize = 10;
            }

            long totalPage = totalCount % pageSize == 0 ? totalCount / pageSize : totalCount / pageSize + 1;
            //original always return last page item if page number more than totalpage
            //now update to return empty if page number more than totalpage
            if (pageNo > totalPage)
            {
                return (new List<TEntity>(), totalCount);
            }

            var records = await query.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            return (records, totalCount);
        }
    }
}
