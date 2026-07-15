namespace DeepCore.RequestHandlers.Products
{
    public class PatchProductStatusRequest : IRequest<PatchProductStatusResponse>
    {
        public long Id { get; set; }
        public int Status { get; set; }
    }
}
