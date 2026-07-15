namespace DeepCore.RequestHandlers.Products
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public string? Unit { get; set; }
        public decimal? Price { get; set; }
    }
}
