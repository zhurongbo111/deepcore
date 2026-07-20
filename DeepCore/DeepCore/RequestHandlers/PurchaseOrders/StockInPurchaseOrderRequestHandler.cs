namespace DeepCore.RequestHandlers.PurchaseOrders
{
    using DeepCore.DAL.Repository.Interfaces;
    using DeepCore.DAL.Entities;
    using System.Linq;
    using DeepCore.RequestHandlers.Shared;

    public class StockInPurchaseOrderRequestHandler : IRequestHandler<StockInPurchaseOrderRequest, StockInPurchaseOrderResponse>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StockInPurchaseOrderRequestHandler(IPurchaseOrderRepository purchaseOrderRepository, IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _inventoryRepository = inventoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<StockInPurchaseOrderResponse> HandleAsync(StockInPurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            using (var work = await _unitOfWork.BeginWorkAsync(cancellationToken))
            {
                try
                {
                    var order = await _purchaseOrderRepository.GetByIdAsync(request.Id, cancellationToken);

                    if (order == null)
                    {
                        return new StockInPurchaseOrderResponse { Success = false };
                    }

                    // Basic implementation: add quantities to inventory for each item
                    foreach (var item in order.Items)
                    {
                        var adjustResult = await RequestHandlerSharing.AdjustInventory(_inventoryRepository, item.ProductId, item.Quantity, cancellationToken);
                        if (!adjustResult.Item1)
                        {
                            throw new Exception(adjustResult.Item2);
                        }
                    }

                    order.Status = PurchaseOrderStatus.Stocked; // stocked
                    await _purchaseOrderRepository.UpdateAsync(order, cancellationToken);
                    await work.CommitAsync(cancellationToken);

                    return new StockInPurchaseOrderResponse { Success = true };
                }
                catch
                {
                    await work.RollbackAsync(cancellationToken);

                    return new StockInPurchaseOrderResponse { Success = false };
                }
                
            }
            
        }
    }
}
