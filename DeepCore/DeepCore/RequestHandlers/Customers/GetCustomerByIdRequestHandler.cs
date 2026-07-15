namespace DeepCore.RequestHandlers.Customers
{
    public class GetCustomerByIdRequestHandler : IRequestHandler<GetCustomerByIdRequest, GetCustomerByIdResponse>
    {
        public Task<GetCustomerByIdResponse> HandleAsync(GetCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
