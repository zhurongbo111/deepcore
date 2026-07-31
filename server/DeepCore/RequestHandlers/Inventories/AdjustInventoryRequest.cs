using System.ComponentModel.DataAnnotations;

namespace DeepCore.RequestHandlers.Inventories
{
    public class AdjustInventoryRequest : IRequest<AdjustInventoryResponse>
    {
        public long ProductId { get; set; }
        public decimal QuantityDifference { get; set; }
        [MaxLength(500)]
        public string? Reason { get; set; }
    }
}
