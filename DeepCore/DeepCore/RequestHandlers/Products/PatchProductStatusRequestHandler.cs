using System.Threading;

namespace DeepCore.RequestHandlers.Products
{
    public class PatchProductStatusRequestHandler : IRequestHandler<PatchProductStatusRequest, PatchProductStatusResponse>
    {
        public Task<PatchProductStatusResponse> HandleAsync(PatchProductStatusRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
