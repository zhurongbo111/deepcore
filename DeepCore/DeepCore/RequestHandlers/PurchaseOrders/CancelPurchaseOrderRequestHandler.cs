namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class CancelPurchaseOrderRequestHandler : IRequestHandler<CancelPurchaseOrderRequest, CancelPurchaseOrderResponse>
    {
        public Task<CancelPurchaseOrderResponse> HandleAsync(CancelPurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
