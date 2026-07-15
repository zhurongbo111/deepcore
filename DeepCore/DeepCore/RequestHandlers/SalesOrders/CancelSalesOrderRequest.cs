namespace DeepCore.RequestHandlers.SalesOrders
{
    public class CancelSalesOrderRequest : IRequest<CancelSalesOrderResponse>
    {
        public long Id { get; set; }
    }
}
