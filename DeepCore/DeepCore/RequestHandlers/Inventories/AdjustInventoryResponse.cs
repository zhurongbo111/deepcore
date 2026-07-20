using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Inventories
{
    public class AdjustInventoryResponse : BaseResponse
    {
        public long ProductId { get; set; }
        public decimal Quantity { get; set; }
    }
}
