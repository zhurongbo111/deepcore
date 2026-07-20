using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.Customers
{
    public class PatchCustomerStatusRequest : IRequest<PatchCustomerStatusResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public int Status { get; set; }
    }
}
