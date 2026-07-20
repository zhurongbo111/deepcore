namespace DeepCore.RequestHandlers.PurchaseOrders
{
    using DeepCore.DAL.Repository.Interfaces;
    using DeepCore.DAL.Entities;

    public class CancelPurchaseOrderRequestHandler : IRequestHandler<CancelPurchaseOrderRequest, CancelPurchaseOrderResponse>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public CancelPurchaseOrderRequestHandler(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<CancelPurchaseOrderResponse> HandleAsync(CancelPurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _purchaseOrderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (order == null)
            {
                return new CancelPurchaseOrderResponse { Success = false };
            }

            order.Status = PurchaseOrderStatus.Canceled;

            await _purchaseOrderRepository.UpdateAsync(order, cancellationToken);

            return new CancelPurchaseOrderResponse { Id = order.Id };
        }
    }
}
