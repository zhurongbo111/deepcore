namespace DeepCore.RequestHandlers.SalesOrders
{
    public class SubmitSalesOrderRequestHandler : IRequestHandler<SubmitSalesOrderRequest, SubmitSalesOrderResponse>
    {
        public Task<SubmitSalesOrderResponse> HandleAsync(SubmitSalesOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
