using System.Threading;

namespace DeepCore.RequestHandlers.Suppliers
{

    public class PatchSupplierStatusRequestHandler : IRequestHandler<PatchSupplierStatusRequest, PatchSupplierStatusResponse>
    {
        public Task<PatchSupplierStatusResponse> HandleAsync(PatchSupplierStatusRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
