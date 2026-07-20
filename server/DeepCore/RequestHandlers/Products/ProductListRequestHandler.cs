using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using DeepCore.RequestHandlers.Shared;
using System.Threading;

namespace DeepCore.RequestHandlers.Products
{
    public class ProductListRequestHandler : IRequestHandler<ProductListRequest, ProductListResponse>
    {
        private readonly IProductRepository _productRepository;

        public ProductListRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductListResponse> HandleAsync(ProductListRequest request, CancellationToken cancellationToken)
        {
            (IEnumerable<Product> products, long total) = await _productRepository.GetPagedAsync(request.Page, request.PageSize, request.KeyWord, request.Status, cancellationToken);
            
            return new ProductListResponse
            {
                Success = true,
                Items = products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    Unit = p.Unit,
                    PurchasePrice = p.PurchasePrice,
                    SalePrice = p.SalePrice,
                    Status = p.Status,
                }).ToList(),
                TotalCount = total
            };
        }
    }
}
