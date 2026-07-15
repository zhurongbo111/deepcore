using System.Threading;

namespace DeepCore.RequestHandlers.Products
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        public Task<CreateProductResponse> HandleAsync(CreateProductRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
