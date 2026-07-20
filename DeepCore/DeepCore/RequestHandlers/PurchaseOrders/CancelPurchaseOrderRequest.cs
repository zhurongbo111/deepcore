using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class CancelPurchaseOrderRequest : IRequest<CancelPurchaseOrderResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}
