using DeepCore.RequestHandlers.Shared;
using System;

namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class PurchaseOrderListRequest : PagedRequest, IRequest<PurchaseOrderListResponse>
    {
        public string? OrderNumber { get; set; }
        public long? SupplierId { get; set; }
        public int? Status { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
