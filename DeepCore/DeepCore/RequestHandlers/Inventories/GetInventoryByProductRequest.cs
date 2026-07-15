namespace DeepCore.RequestHandlers.Inventories
{
    public class GetInventoryByProductRequest : IRequest<GetInventoryByProductResponse>
    {
        public long ProductId { get; set; }
    }
}
