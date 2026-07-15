using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Suppliers
{
    public class SupplierListRequest : PagedRequest, IRequest<SupplierListResponse>
    {
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
    }
}
