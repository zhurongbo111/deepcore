using DeepCore.DAL.Repository.Interfaces;
using System.Threading;

namespace DeepCore.RequestHandlers.Products
{
    public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<UpdateProductResponse> HandleAsync(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            
            if(product == null)
            {
                return new UpdateProductResponse
                {
                    Success = false,
                    Message = "Product is not found."
                };
            }

            product.SalePrice = request.SalePrice ?? product.SalePrice;
            product.PurchasePrice = request.PurchasePrice ?? product.PurchasePrice;
            product.Unit = request.Unit ?? product.Unit;
            product.Name = request.Name ?? product.Name;

            await _productRepository.UpdateAsync(product, cancellationToken);

            return new UpdateProductResponse
            {
                Success = true,
                Message = "Product updated successfully."
            };
        }
    }
}
