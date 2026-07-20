using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Inventories
{

    public class AdjustInventoryRequestHandler : IRequestHandler<AdjustInventoryRequest, AdjustInventoryResponse>
    {
        private readonly IInventoryRepository _inventoryRepository;

        public AdjustInventoryRequestHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<AdjustInventoryResponse> HandleAsync(AdjustInventoryRequest request, CancellationToken cancellationToken)
        {
            var result = await RequestHandlerSharing.AdjustInventory(_inventoryRepository, request.ProductId, request.QuantityDifference, cancellationToken);

            return new AdjustInventoryResponse
            {
                Success = result.Item1,
                Message = result.Item2,
            };
        }
    }
}
