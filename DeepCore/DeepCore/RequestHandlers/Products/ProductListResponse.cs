using System.Collections.Generic;

namespace DeepCore.RequestHandlers.Products
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public decimal? Price { get; set; }
        public int Status { get; set; }
    }

    public class ProductListResponse
    {
        public IEnumerable<ProductDto>? Items { get; set; }
        public long TotalCount { get; set; }
    }
}
