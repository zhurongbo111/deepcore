namespace DeepCore.RequestHandlers.Inventories
{
    public class InventoryListRequestHandler : IRequestHandler<InventoryListRequest, InventoryListResponse>
    {
        public Task<InventoryListResponse> HandleAsync(InventoryListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class GetInventoryByProductRequestHandler : IRequestHandler<GetInventoryByProductRequest, GetInventoryByProductResponse>
    {
        public Task<GetInventoryByProductResponse> HandleAsync(GetInventoryByProductRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class AdjustInventoryRequestHandler : IRequestHandler<AdjustInventoryRequest, AdjustInventoryResponse>
    {
        public Task<AdjustInventoryResponse> HandleAsync(AdjustInventoryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
