namespace DeepCore.RequestHandlers.SalesOrders
{
    public class SubmitSalesOrderRequest : IRequest<SubmitSalesOrderResponse>
    {
        public long Id { get; set; }
    }
}
