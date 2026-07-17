using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.Suppliers
{
    public class UpdateSupplierRequest : IRequest<UpdateSupplierResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Remark { get; set; }
    }
}
