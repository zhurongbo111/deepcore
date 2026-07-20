using DeepCore.RequestHandlers.Shared;
using System.Collections.Generic;

namespace DeepCore.RequestHandlers.Inventories
{
    public class InventoryItemDto
    {
        public long ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal LockedQuantity { get; set; }
        public decimal AvailableQuantity { get; set; }
    }

    public class InventoryListResponse : PagedResponse<InventoryItemDto>
    {
    }
}
