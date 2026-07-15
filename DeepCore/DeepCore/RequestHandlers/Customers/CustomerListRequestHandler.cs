namespace DeepCore.RequestHandlers.Customers
{
    public class CustomerListRequestHandler : IRequestHandler<CustomerListRequest, CustomerListResponse>
    {
        public Task<CustomerListResponse> HandleAsync(CustomerListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
