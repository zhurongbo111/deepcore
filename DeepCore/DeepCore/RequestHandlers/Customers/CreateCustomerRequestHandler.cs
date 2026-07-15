namespace DeepCore.RequestHandlers.Customers
{
    public class CreateCustomerRequestHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        public Task<CreateCustomerResponse> HandleAsync(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
