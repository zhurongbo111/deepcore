namespace DeepCore.RequestHandlers.Products
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public decimal? Price { get; set; }
    }
}
