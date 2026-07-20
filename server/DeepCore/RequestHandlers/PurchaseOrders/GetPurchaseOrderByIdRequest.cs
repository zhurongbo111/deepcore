using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class GetPurchaseOrderByIdRequest : IRequest<GetPurchaseOrderByIdResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}
