using System.Threading;
using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Products
{
    public class ProductListRequestHandler : IRequestHandler<ProductListRequest, ProductListResponse>
    {
        public Task<ProductListResponse> HandleAsync(ProductListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
