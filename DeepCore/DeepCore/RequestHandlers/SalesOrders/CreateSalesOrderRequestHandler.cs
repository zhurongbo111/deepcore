namespace DeepCore.RequestHandlers.SalesOrders
{
    public class CreateSalesOrderRequestHandler : IRequestHandler<CreateSalesOrderRequest, CreateSalesOrderResponse>
    {
        public Task<CreateSalesOrderResponse> HandleAsync(CreateSalesOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
