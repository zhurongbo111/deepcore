namespace DeepCore.RequestHandlers.Products
{
    public class GetProductByIdResponse : BaseResponse
    {
        public long Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int Status { get; set; }
    }
}
