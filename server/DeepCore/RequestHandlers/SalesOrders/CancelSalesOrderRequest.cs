using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.SalesOrders
{
    public class CancelSalesOrderRequest : IRequest<CancelSalesOrderResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}
