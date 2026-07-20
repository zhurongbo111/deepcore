using DeepCore.DAL.Entities;
using DeepCore.RequestHandlers.Shared;
using System.Collections.Generic;

namespace DeepCore.RequestHandlers.SalesOrders
{
    public class SalesOrderListItemDto
    {
        public long Id { get; set; }
        public string? OrderNumber { get; set; }
        public SalesOrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class SalesOrderListResponse : PagedResponse<SalesOrderListItemDto>
    {
    }
}
