using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.Products
{
    public class PatchProductStatusRequest : IRequest<PatchProductStatusResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public int Status { get; set; }
    }
}
