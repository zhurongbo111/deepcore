using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Inventories
{
    public class InventoryListRequest : PagedRequest, IRequest<InventoryListResponse>
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
    }
}
