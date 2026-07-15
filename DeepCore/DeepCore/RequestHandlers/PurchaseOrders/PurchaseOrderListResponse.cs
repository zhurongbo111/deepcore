using System.Collections.Generic;

namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class PurchaseOrderListItemDto
    {
        public long Id { get; set; }
        public string? OrderNumber { get; set; }
        public int Status { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class PurchaseOrderListResponse
    {
        public IEnumerable<PurchaseOrderListItemDto>? Items { get; set; }
        public long TotalCount { get; set; }
    }
}
