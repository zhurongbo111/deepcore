using System.Collections.Generic;

namespace DeepCore.RequestHandlers.Inventories
{
    public class InventoryItemDto
    {
        public long ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCode { get; set; }
        public int Quantity { get; set; }
        public int LockedQuantity { get; set; }
        public int AvailableQuantity { get; set; }
    }

    public class InventoryListResponse
    {
        public IEnumerable<InventoryItemDto>? Items { get; set; }
        public long TotalCount { get; set; }
    }
}
