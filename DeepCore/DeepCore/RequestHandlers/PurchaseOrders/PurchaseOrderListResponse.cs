using DeepCore.DAL.Entities;
using DeepCore.RequestHandlers.Shared;
using System.Collections.Generic;

namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class PurchaseOrderListItemDto
    {
        public long Id { get; set; }
        public string? OrderNumber { get; set; }
        public PurchaseOrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class PurchaseOrderListResponse : PagedResponse<PurchaseOrderListItemDto>
    {
    }
}
