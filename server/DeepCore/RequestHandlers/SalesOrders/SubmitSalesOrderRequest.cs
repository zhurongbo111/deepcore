using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.SalesOrders
{
    public class SubmitSalesOrderRequest : IRequest<SubmitSalesOrderResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}
