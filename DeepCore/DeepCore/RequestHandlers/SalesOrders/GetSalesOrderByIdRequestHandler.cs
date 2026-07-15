namespace DeepCore.RequestHandlers.SalesOrders
{
    public class GetSalesOrderByIdRequestHandler : IRequestHandler<GetSalesOrderByIdRequest, GetSalesOrderByIdResponse>
    {
        public Task<GetSalesOrderByIdResponse> HandleAsync(GetSalesOrderByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
