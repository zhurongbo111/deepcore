using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.RequestHandlers.Inventories
{
    public class InventoryListRequestHandler : IRequestHandler<InventoryListRequest, InventoryListResponse>
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryListRequestHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<InventoryListResponse> HandleAsync(InventoryListRequest request, CancellationToken cancellationToken)
        {
            (IEnumerable<DeepCore.DAL.Entities.Inventory> items, long total) = await _inventoryRepository.GetPagedAsync(request.Page, request.PageSize, request.Name, request.Code, cancellationToken);

            var dtoItems = items.Select(i => new InventoryItemDto
            {
                ProductId = i.ProductId,
                ProductName = i.Product?.Name,
                ProductCode = i.Product?.Code,
                Quantity = i.Quantity,
                LockedQuantity = i.LockedQuantity,
                AvailableQuantity = i.AvailableQuantity
            }).ToList();

            return new InventoryListResponse
            {
                Success = true,
                Items = dtoItems,
                TotalCount = total
            };
        }
    }
}
