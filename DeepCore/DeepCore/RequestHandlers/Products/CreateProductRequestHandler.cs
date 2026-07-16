using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using System.Threading;

namespace DeepCore.RequestHandlers.Products
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CreateProductResponse> HandleAsync(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var prod = new Product
            {
                Code = request.Code,
                Name = request.Name,
                Unit = request.Unit,
                SalePrice = request.SalePrice,
                PurchasePrice = request.PurchasePrice,
                Status = request.Status,
            };

            await _productRepository.InsertAsync(prod, cancellationToken);

            return new CreateProductResponse
            {
                Success = true,   
                Id = prod.Id
            };
        }
    }
}
