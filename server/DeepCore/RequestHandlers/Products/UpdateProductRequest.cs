using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.Products
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        [Required, MaxLength(20)]
        public string? Unit { get; set; }
        [Required, Range(0.00, double.MaxValue)]
        public decimal? SalePrice { get; set; }
        [Required, Range(0.00, double.MaxValue)]
        public decimal? PurchasePrice { get; set; }
    }
}
