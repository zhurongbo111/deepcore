namespace DeepCore.RequestHandlers.PurchaseOrders
{
    using DeepCore.DAL.Entities;
    using DeepCore.DAL.Repository.Interfaces;
    using DeepCore.Services;
    using System.Linq;

    public class CreatePurchaseOrderRequestHandler : IRequestHandler<CreatePurchaseOrderRequest, CreatePurchaseOrderResponse>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly ICodeGeneraterService _codeGeneraterService;

        public CreatePurchaseOrderRequestHandler(IPurchaseOrderRepository purchaseOrderRepository, ICodeGeneraterService codeGeneraterService)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _codeGeneraterService = codeGeneraterService;
        }

        public async Task<CreatePurchaseOrderResponse> HandleAsync(CreatePurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            var order = new PurchaseOrder
            {
                SupplierId = request.SupplierId,
                Status = (PurchaseOrderStatus)request.Status,
                OrderDate = DateTimeOffset.UtcNow,
                OrderNo = await _codeGeneraterService.GeneratePurchaseOrderCodeAsync(cancellationToken),
                Items = request.Items?.Select(i => new PurchaseOrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Price = i.UnitPrice,
                    Amount = i.Amount
                }).ToList() ?? new List<PurchaseOrderItem>()
            };

            order.TotalAmount = order.Items.Sum(x => x.Amount);

            await _purchaseOrderRepository.InsertAsync(order, cancellationToken);

            return new CreatePurchaseOrderResponse { Success = true, Id = order.Id };
        }
    }
}
