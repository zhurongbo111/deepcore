namespace DeepCore.RequestHandlers.SalesOrders
{
    public class StockOutSalesOrderRequest : IRequest<StockOutSalesOrderResponse>
    {
        public long Id { get; set; }
    }
}
