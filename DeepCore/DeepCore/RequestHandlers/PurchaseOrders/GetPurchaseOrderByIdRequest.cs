namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class GetPurchaseOrderByIdRequest : IRequest<GetPurchaseOrderByIdResponse>
    {
        public long Id { get; set; }
    }
}
