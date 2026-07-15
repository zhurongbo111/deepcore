using System.Collections.Generic;

namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class UpdatePurchaseOrderRequest : IRequest<UpdatePurchaseOrderResponse>
    {
        public long Id { get; set; }
        public long SupplierId { get; set; }
        public List<PurchaseOrderItemDto>? Items { get; set; }
    }
}
