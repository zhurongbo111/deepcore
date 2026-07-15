namespace DeepCore.RequestHandlers.Suppliers
{
    public class GetSupplierByIdRequestHandler : IRequestHandler<GetSupplierByIdRequest, GetSupplierByIdResponse>
    {
        public Task<GetSupplierByIdResponse> HandleAsync(GetSupplierByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
