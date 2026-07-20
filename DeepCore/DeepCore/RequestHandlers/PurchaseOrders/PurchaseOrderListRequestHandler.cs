namespace DeepCore.RequestHandlers.PurchaseOrders
{
    using DeepCore.DAL.Repository.Interfaces;
    using System.Linq;

    public class PurchaseOrderListRequestHandler : IRequestHandler<PurchaseOrderListRequest, PurchaseOrderListResponse>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderListRequestHandler(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<PurchaseOrderListResponse> HandleAsync(PurchaseOrderListRequest request, CancellationToken cancellationToken)
        {
            (IEnumerable<DeepCore.DAL.Entities.PurchaseOrder> items, long total) = await _purchaseOrderRepository.GetPagedAsync(request.Page, request.PageSize, request.OrderNumber, request.SupplierId, request.Status, request.From, request.To, cancellationToken);

            var dtoItems = items.Select(p => new PurchaseOrderListItemDto
            {
                Id = p.Id,
                OrderNumber = p.OrderNo,
                Status = p.Status,
                TotalAmount = p.TotalAmount
            }).ToList();

            return new PurchaseOrderListResponse
            {
                Success = true,
                Items = dtoItems,
                TotalCount = total
            };
        }
    }
}
