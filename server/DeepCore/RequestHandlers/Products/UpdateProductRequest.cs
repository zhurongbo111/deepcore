using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.Products
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(20)]
        public string? Unit { get; set; }
        [Range(0.00, double.MaxValue)]
        public decimal? SalePrice { get; set; }
        [Range(0.00, double.MaxValue)]
        public decimal? PurchasePrice { get; set; }
    }
}
