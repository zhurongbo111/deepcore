using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.Customers
{
    public class PatchCustomerStatusRequest : IRequest<PatchCustomerStatusResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
        [Required, Range(0, 1)]
        public int Status { get; set; }
    }
}
