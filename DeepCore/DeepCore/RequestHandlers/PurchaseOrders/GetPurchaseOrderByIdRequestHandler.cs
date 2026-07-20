namespace DeepCore.RequestHandlers.PurchaseOrders
{
    using DeepCore.DAL.Repository.Interfaces;
    using System.Linq;

    public class GetPurchaseOrderByIdRequestHandler : IRequestHandler<GetPurchaseOrderByIdRequest, GetPurchaseOrderByIdResponse>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public GetPurchaseOrderByIdRequestHandler(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<GetPurchaseOrderByIdResponse> HandleAsync(GetPurchaseOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var order = await _purchaseOrderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (order == null)
            {
                return new GetPurchaseOrderByIdResponse { Success = false };
            }

            var items = order.Items.Select(i => new PurchaseOrderDetailItemDto
            {
                ProductId = i.ProductId,
                ProductName = i.Product?.Name,
                Quantity = (int)i.Quantity,
                UnitPrice = i.Price,
                Amount = i.Amount
            }).ToList();

            return new GetPurchaseOrderByIdResponse
            {
                Success = true,
                Id = order.Id,
                OrderNumber = order.OrderNo,
                Status = order.Status,
                TotalAmount = order.TotalAmount,
                Items = items
            };
        }
    }
}
