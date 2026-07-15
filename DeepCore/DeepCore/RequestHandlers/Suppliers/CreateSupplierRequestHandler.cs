namespace DeepCore.RequestHandlers.Suppliers
{
    public class CreateSupplierRequestHandler : IRequestHandler<CreateSupplierRequest, CreateSupplierResponse>
    {
        public Task<CreateSupplierResponse> HandleAsync(CreateSupplierRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
