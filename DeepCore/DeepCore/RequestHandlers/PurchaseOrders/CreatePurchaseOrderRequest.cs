using System.Collections.Generic;

namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class PurchaseOrderItemDto
    {
        public long ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }

    public class CreatePurchaseOrderRequest : IRequest<CreatePurchaseOrderResponse>
    {
        public long SupplierId { get; set; }
        public int Status { get; set; } // 0 draft, 1 active
        public List<PurchaseOrderItemDto>? Items { get; set; }
    }
}
