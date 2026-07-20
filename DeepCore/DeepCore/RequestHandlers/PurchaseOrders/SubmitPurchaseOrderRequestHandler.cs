namespace DeepCore.RequestHandlers.PurchaseOrders
{
    using DeepCore.DAL.Repository.Interfaces;
    using DeepCore.DAL.Entities;

    public class SubmitPurchaseOrderRequestHandler : IRequestHandler<SubmitPurchaseOrderRequest, SubmitPurchaseOrderResponse>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public SubmitPurchaseOrderRequestHandler(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<SubmitPurchaseOrderResponse> HandleAsync(SubmitPurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _purchaseOrderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (order == null)
            {
                return new SubmitPurchaseOrderResponse { Success = false };
            }

            order.Status = PurchaseOrderStatus.Submitted; // submitted/active
            if (order.OrderDate == default)
            {
                order.OrderDate = DateTimeOffset.UtcNow;
            }

            await _purchaseOrderRepository.UpdateAsync(order, cancellationToken);

            return new SubmitPurchaseOrderResponse { Success = true };
        }
    }
}
