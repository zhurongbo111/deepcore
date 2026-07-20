using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.Inventories
{
    public class GetInventoryByProductRequest : IRequest<GetInventoryByProductResponse>
    {
        [JsonIgnore]
        public long ProductId { get; set; }
    }
}
