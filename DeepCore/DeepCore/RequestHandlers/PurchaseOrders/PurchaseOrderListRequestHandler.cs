namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class PurchaseOrderListRequestHandler : IRequestHandler<PurchaseOrderListRequest, PurchaseOrderListResponse>
    {
        public Task<PurchaseOrderListResponse> HandleAsync(PurchaseOrderListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
