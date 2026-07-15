namespace DeepCore.RequestHandlers.PurchaseOrders
{
    public class GetPurchaseOrderByIdRequestHandler : IRequestHandler<GetPurchaseOrderByIdRequest, GetPurchaseOrderByIdResponse>
    {
        public Task<GetPurchaseOrderByIdResponse> HandleAsync(GetPurchaseOrderByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
