using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Inventories
{
    public class GetInventoryByProductResponse : BaseResponse
    {
        public long ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal LockedQuantity { get; set; }
        public decimal AvailableQuantity { get; set; }
    }
}
