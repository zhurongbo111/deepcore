namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class CancelPurchaseOrderRequest : IRequest<CancelPurchaseOrderResponse>
    {
        public long Id { get; set; }
    }
}
