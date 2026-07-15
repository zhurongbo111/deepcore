namespace DeepCore.RequestHandlers.Inventories
{
    public class GetInventoryByProductResponse
    {
        public long ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public int LockedQuantity { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
