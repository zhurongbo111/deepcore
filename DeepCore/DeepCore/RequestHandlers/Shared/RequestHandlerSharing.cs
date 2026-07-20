using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.RequestHandlers.Shared
{
    public static class RequestHandlerSharing
    {
        internal static async Task<(bool, string?)> AdjustInventory(IInventoryRepository inventoryRepository,
            long productId,
            decimal quantityDifference,
            CancellationToken cancellationToken)
        {
            var inventory = await inventoryRepository.GetByProductIdAsync(productId, cancellationToken);

            if (inventory == null)
            {
                if (quantityDifference < 0)
                {
                    return (false, "Cannot adjust inventory for a non-existing product with a negative quantity.");
                }

                inventory = new Inventory
                {
                    ProductId = productId,
                    Quantity = quantityDifference,
                    LockedQuantity = 0,
                    AvailableQuantity = quantityDifference
                };

                await inventoryRepository.InsertAsync(inventory, cancellationToken);
            }
            else
            {
                inventory.Quantity += quantityDifference;
                inventory.AvailableQuantity = inventory.Quantity - inventory.LockedQuantity;

                if (inventory.AvailableQuantity < 0 || inventory.Quantity < 0)
                {
                    return (false, "Quantity and AvailableQuantity can not be negative");
                }

                await inventoryRepository.UpdateAsync(inventory, cancellationToken);
            }

            return (true, null);
        }
    }
}
