using System.Collections.Generic;

namespace DeepCore.RequestHandlers.SalesOrders
{
    public class SalesOrderItemDto
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
    }

    public class CreateSalesOrderRequest : IRequest<CreateSalesOrderResponse>
    {
        public long CustomerId { get; set; }
        public int Status { get; set; } // 0 draft, 1 active
        public List<SalesOrderItemDto>? Items { get; set; }
    }
}
