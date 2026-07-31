using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.Products
{
    public class PatchProductStatusRequest : IRequest<PatchProductStatusResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
        [Required, Range(0, 1)]
        public int Status { get; set; }
    }
}
