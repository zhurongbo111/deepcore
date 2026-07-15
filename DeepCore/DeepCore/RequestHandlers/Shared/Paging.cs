using System.Collections.Generic;

namespace DeepCore.RequestHandlers.Shared
{
    public class PagedRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class PagedResponse<T>
    {
        public IEnumerable<T>? Items { get; set; }
        public long TotalCount { get; set; }
    }
}
