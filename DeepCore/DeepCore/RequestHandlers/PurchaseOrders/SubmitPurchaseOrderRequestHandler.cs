namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class SubmitPurchaseOrderRequestHandler : IRequestHandler<SubmitPurchaseOrderRequest, SubmitPurchaseOrderResponse>
    {
        public Task<SubmitPurchaseOrderResponse> HandleAsync(SubmitPurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
