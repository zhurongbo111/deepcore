namespace DeepCore.RequestHandlers.Inventories
{
    public class GetInventoryByProductRequestHandler : IRequestHandler<GetInventoryByProductRequest, GetInventoryByProductResponse>
    {
        private readonly DeepCore.DAL.Repository.Interfaces.IInventoryRepository _inventoryRepository;

        public GetInventoryByProductRequestHandler(DeepCore.DAL.Repository.Interfaces.IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<GetInventoryByProductResponse> HandleAsync(GetInventoryByProductRequest request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetByProductIdAsync(request.ProductId, cancellationToken);

            if (inventory == null)
            {
                return new GetInventoryByProductResponse { Success = false, Message = "Inventory not found for the specified product." };
            }

            return new GetInventoryByProductResponse
            {
                Success = true,
                ProductId = inventory.ProductId,
                ProductName = inventory.Product?.Name,
                Quantity = inventory.Quantity,
                LockedQuantity = inventory.LockedQuantity,
                AvailableQuantity = inventory.AvailableQuantity
            };
        }
    }
}
