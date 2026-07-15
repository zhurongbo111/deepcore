namespace DeepCore.RequestHandlers.SalesOrders
{
    public class CancelSalesOrderRequestHandler : IRequestHandler<CancelSalesOrderRequest, CancelSalesOrderResponse>
    {
        public Task<CancelSalesOrderResponse> HandleAsync(CancelSalesOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
