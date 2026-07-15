namespace DeepCore.RequestHandlers.Customers
{
    public class UpdateCustomerRequestHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        public Task<UpdateCustomerResponse> HandleAsync(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
