using System.Threading;

namespace DeepCore.RequestHandlers.Products
{
    public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        public Task<GetProductByIdResponse> HandleAsync(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
