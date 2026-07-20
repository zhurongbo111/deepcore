using DeepCore.DAL.Entities;
using DeepCore.RequestHandlers.Shared;
using System.Collections.Generic;

namespace DeepCore.RequestHandlers.SalesOrders
{
    public class SalesOrderDetailItemDto
    {
        public long ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
    }

    public class GetSalesOrderByIdResponse : BaseResponse
    {
        public long Id { get; set; }
        public string? OrderNumber { get; set; }
        public SalesOrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public IEnumerable<SalesOrderDetailItemDto>? Items { get; set; }
    }
}
