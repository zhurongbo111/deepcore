namespace DeepCore.RequestHandlers.Inventories
{
    public class AdjustInventoryRequest : IRequest<AdjustInventoryResponse>
    {
        public long ProductId { get; set; }
        public int QuantityDifference { get; set; }
        public string? Reason { get; set; }
    }
}
