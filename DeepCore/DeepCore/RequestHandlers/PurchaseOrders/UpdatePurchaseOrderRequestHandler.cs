namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class UpdatePurchaseOrderRequestHandler : IRequestHandler<UpdatePurchaseOrderRequest, UpdatePurchaseOrderResponse>
    {
        public Task<UpdatePurchaseOrderResponse> HandleAsync(UpdatePurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
