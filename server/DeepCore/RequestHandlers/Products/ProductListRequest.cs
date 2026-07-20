using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Products
{
    public class ProductListRequest : PagedRequest, IRequest<ProductListResponse>
    {
        public string? KeyWord { get; set; }
        public string? Code { get; set; }
        public int? Status { get; set; }
    }
}
