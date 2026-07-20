namespace DeepCore.RequestHandlers.Products
{
    public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
    {
        public long Id { get; set; }
    }
}
