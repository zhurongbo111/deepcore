using DeepCore.RequestHandlers.Shared;
using System.Collections.Generic;

namespace DeepCore.RequestHandlers.Products
{
    public class ProductDto
    {
        public long Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Unit { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Status { get; set; }
    }

    public class ProductListResponse : PagedResponse<ProductDto>
    {
    }
}
