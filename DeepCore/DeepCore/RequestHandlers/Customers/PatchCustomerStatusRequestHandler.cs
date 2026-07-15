using System.Threading;

namespace DeepCore.RequestHandlers.Customers
{

    public class PatchCustomerStatusRequestHandler : IRequestHandler<PatchCustomerStatusRequest, PatchCustomerStatusResponse>
    {
        public Task<PatchCustomerStatusResponse> HandleAsync(PatchCustomerStatusRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
