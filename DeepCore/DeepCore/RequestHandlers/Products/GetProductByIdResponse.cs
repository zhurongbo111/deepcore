namespace DeepCore.RequestHandlers.Products
{
    public class GetProductByIdResponse
    {
        public long Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public decimal? Price { get; set; }
        public int Status { get; set; }
    }
}
