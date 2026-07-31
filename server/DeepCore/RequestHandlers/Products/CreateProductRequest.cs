using System.ComponentModel.DataAnnotations;

namespace DeepCore.RequestHandlers.Products
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        [Required, MaxLength(50)]
        public required string Code { get; set; }
        [Required, MaxLength(100)]
        public required string Name { get; set; }
        [Required, MaxLength(20)]
        public required string Unit { get; set; }
        [Required, Range(0.00, double.MaxValue)]
        public required decimal PurchasePrice { get; set; }
        [Required, Range(0.00, double.MaxValue)]
        public required decimal SalePrice { get; set; }
        [Required, Range(0,1)]
        public required int Status { get; set; } = 1;

    }
}
