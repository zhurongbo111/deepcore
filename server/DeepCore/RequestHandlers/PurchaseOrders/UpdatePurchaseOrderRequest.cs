using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class UpdatePurchaseOrderRequest : IRequest<UpdatePurchaseOrderResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public long SupplierId { get; set; }
        public List<PurchaseOrderItemDto>? Items { get; set; }
    }
}
