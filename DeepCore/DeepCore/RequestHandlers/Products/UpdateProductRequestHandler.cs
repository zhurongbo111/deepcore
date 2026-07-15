using System.Threading;

namespace DeepCore.RequestHandlers.Products
{
    public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        public Task<UpdateProductResponse> HandleAsync(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
