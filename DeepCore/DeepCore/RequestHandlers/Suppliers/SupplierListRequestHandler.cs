namespace DeepCore.RequestHandlers.Suppliers
{
    public class SupplierListRequestHandler : IRequestHandler<SupplierListRequest, SupplierListResponse>
    {
        public Task<SupplierListResponse> HandleAsync(SupplierListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
