namespace DeepCore.RequestHandlers.Products
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Unit { get; set; }
        public required decimal PurchasePrice { get; set; }
        public required decimal SalePrice { get; set; }
        public required int Status { get; set; } = 1;

    }
}
