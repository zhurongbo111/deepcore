namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class CreatePurchaseOrderRequestHandler : IRequestHandler<CreatePurchaseOrderRequest, CreatePurchaseOrderResponse>
    {
        public Task<CreatePurchaseOrderResponse> HandleAsync(CreatePurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
