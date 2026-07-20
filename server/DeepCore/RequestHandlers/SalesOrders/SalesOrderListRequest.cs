using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.SalesOrders
{
    public class SalesOrderListRequest : PagedRequest, IRequest<SalesOrderListResponse>
    {
        public string? OrderNumber { get; set; }
        public long? CustomerId { get; set; }
        public int? Status { get; set; }
    }
}
