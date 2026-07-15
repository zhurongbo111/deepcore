namespace DeepCore.RequestHandlers.SalesOrders
{
    public class StockOutSalesOrderRequestHandler : IRequestHandler<StockOutSalesOrderRequest, StockOutSalesOrderResponse>
    {
        public Task<StockOutSalesOrderResponse> HandleAsync(StockOutSalesOrderRequest request, CancellationToken cancellationToken)
        {
            // Core logic requires transaction control and inventory adjustments. Deferred.
            throw new NotImplementedException();
        }
    }
}
