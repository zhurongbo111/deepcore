namespace DeepCore.RequestHandlers.PurchaseOrders
{
    using DeepCore.DAL.Repository.Interfaces;
    using DeepCore.DAL.Entities;
    using System.Linq;

    public class UpdatePurchaseOrderRequestHandler : IRequestHandler<UpdatePurchaseOrderRequest, UpdatePurchaseOrderResponse>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public UpdatePurchaseOrderRequestHandler(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<UpdatePurchaseOrderResponse> HandleAsync(UpdatePurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _purchaseOrderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (order == null || order.Status != PurchaseOrderStatus.Draft)
            {
                return new UpdatePurchaseOrderResponse { Success = false };
            }

            order.SupplierId = request.SupplierId;

            // Replace items: clear existing and add from request
            order.Items.Clear();
            if (request.Items != null)
            {
                foreach (var it in request.Items)
                {
                    order.Items.Add(new PurchaseOrderItem
                    {
                        ProductId = it.ProductId,
                        Quantity = it.Quantity,
                        Price = it.UnitPrice,
                        Amount = it.Amount
                    });
                }
            }

            order.TotalAmount = order.Items.Sum(i => i.Amount);

            await _purchaseOrderRepository.UpdateAsync(order, cancellationToken);

            return new UpdatePurchaseOrderResponse { Success = true };
        }
    }
}
