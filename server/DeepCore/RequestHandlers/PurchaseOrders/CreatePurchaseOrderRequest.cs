using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class PurchaseOrderItemDto
    {
        [Required]
        public long ProductId { get; set; }
        [Range(0.00, double.MaxValue)]
        public decimal UnitPrice { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Range(0.00, double.MaxValue)]
        public decimal Amount { get; set; }
    }

    public class CreatePurchaseOrderRequest : IRequest<CreatePurchaseOrderResponse>
    {
        public long SupplierId { get; set; }
        [Range(0, 1)]
        public int Status { get; set; } // 0 draft, 1 active
        public List<PurchaseOrderItemDto>? Items { get; set; }
    }
}
