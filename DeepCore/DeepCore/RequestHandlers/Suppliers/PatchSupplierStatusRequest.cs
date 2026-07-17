using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.Suppliers
{
    public class PatchSupplierStatusRequest : IRequest<PatchSupplierStatusResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public int Status { get; set; }
    }
}
