namespace DeepCore.RequestHandlers.SalesOrders
{
    using DeepCore.DAL.Repository.Interfaces;
    using DeepCore.DAL.Entities;
    using System.Linq;
    using DeepCore.RequestHandlers.Shared;

    public class StockOutSalesOrderRequestHandler : IRequestHandler<StockOutSalesOrderRequest, StockOutSalesOrderResponse>
    {
        private readonly ISalesOrderRepository _salesOrderRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StockOutSalesOrderRequestHandler(ISalesOrderRepository salesOrderRepository, IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork)
        {
            _salesOrderRepository = salesOrderRepository;
            _inventoryRepository = inventoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<StockOutSalesOrderResponse> HandleAsync(StockOutSalesOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _salesOrderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (order == null)
            {
                return new StockOutSalesOrderResponse { Success = false };
            }

            using (var work = await _unitOfWork.BeginWorkAsync(cancellationToken))
            {
                try
                {
                    // Basic implementation: reduce available inventory by item quantity
                    foreach (var item in order.Items)
                    {
                        var itemResult = await RequestHandlerSharing.AdjustInventory(_inventoryRepository, item.ProductId, item.Quantity, cancellationToken);
                        if (!itemResult.Item1)
                        {
                            throw new Exception(itemResult.Item2);
                        }
                    }

                    order.Status = SalesOrderStatus.StockedOut; // stocked out
                    await _salesOrderRepository.UpdateAsync(order, cancellationToken);
                    await work.CommitAsync(cancellationToken);
                }
                catch
                {
                    await work.RollbackAsync(cancellationToken);
                    return new StockOutSalesOrderResponse { Success = false };
                }

                return new StockOutSalesOrderResponse { Success = true };
            }  
        }
    }
}
