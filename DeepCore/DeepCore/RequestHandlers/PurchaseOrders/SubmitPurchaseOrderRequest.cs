namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class SubmitPurchaseOrderRequest : IRequest<SubmitPurchaseOrderResponse>
    {
        public long Id { get; set; }
    }
}
