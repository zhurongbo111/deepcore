using DeepCore.DAL.Repository.Interfaces;
using System.Threading;

namespace DeepCore.RequestHandlers.Products
{
    public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductByIdResponse> HandleAsync(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            return new GetProductByIdResponse
            {
                Id = request.Id,
                Code = product?.Code,
                Name = product?.Name,
                Status = product?.Status ?? 0,
                Success = true,
                SalePrice = product?.SalePrice,
                PurchasePrice = product?.PurchasePrice,
                Unit = product?.Unit,
            };
        }
    }
}
