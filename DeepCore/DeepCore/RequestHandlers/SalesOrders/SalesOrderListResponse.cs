using System.Collections.Generic;

namespace DeepCore.RequestHandlers.SalesOrders
{
    public class SalesOrderListItemDto
    {
        public long Id { get; set; }
        public string? OrderNumber { get; set; }
        public int Status { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class SalesOrderListResponse
    {
        public IEnumerable<SalesOrderListItemDto>? Items { get; set; }
        public long TotalCount { get; set; }
    }
}
