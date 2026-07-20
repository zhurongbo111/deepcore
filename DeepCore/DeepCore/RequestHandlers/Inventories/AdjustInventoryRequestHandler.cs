using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;

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
            var inventory = await _inventoryRepository.GetByProductIdAsync(request.ProductId, cancellationToken);

            if (inventory == null)
            {
                if(request.QuantityDifference < 0)
                {
                    return new AdjustInventoryResponse
                    {
                        Success = false,
                        Message = "Cannot adjust inventory for a non-existing product with a negative quantity."
                    };
                }

                inventory = new Inventory
                {
                    ProductId = request.ProductId,
                    Quantity = request.QuantityDifference,
                    LockedQuantity = 0,
                    AvailableQuantity = request.QuantityDifference
                };

                await _inventoryRepository.InsertAsync(inventory, cancellationToken);
            }
            else
            {
                inventory.Quantity += request.QuantityDifference;
                inventory.AvailableQuantity = inventory.Quantity - inventory.LockedQuantity;

                if(inventory.AvailableQuantity < 0 || inventory.Quantity < 0)
                {
                    return new AdjustInventoryResponse
                    {
                        Success = false,
                        Message = "Quantity and AvailableQuantity can not be negative"
                    };
                }

                await _inventoryRepository.UpdateAsync(inventory, cancellationToken);
            }

            return new AdjustInventoryResponse
            {
                Success = true,
                ProductId = inventory.ProductId,
                Quantity = inventory.Quantity
            };
        }
    }
}
