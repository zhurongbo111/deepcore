namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class StockInPurchaseOrderRequest : IRequest<StockInPurchaseOrderResponse>
    {
        public long Id { get; set; }
    }
}
