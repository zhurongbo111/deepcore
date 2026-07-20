using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class SubmitPurchaseOrderRequest : IRequest<SubmitPurchaseOrderResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}
