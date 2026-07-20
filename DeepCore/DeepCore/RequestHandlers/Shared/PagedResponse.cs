using DeepCore.DAL.Repository;
using DeepCore.RequestHandlers.Inventories;

namespace DeepCore.RequestHandlers.Shared
{
    public class PagedResponse<T> : BaseResponse
    {
        public IEnumerable<T>? Items { get; set; }
        public long TotalCount { get; set; }
    }
}
