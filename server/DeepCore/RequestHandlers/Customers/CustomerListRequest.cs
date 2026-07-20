using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Customers
{
    public class CustomerListRequest : PagedRequest, IRequest<CustomerListResponse>
    {
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
    }
}
