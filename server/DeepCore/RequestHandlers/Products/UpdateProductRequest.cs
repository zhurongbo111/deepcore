using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.Products
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? PurchasePrice { get; set; }
    }
}
