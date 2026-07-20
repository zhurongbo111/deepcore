using System.Linq;
using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.RequestHandlers.SalesOrders
{
    public class SalesOrderListRequestHandler : IRequestHandler<SalesOrderListRequest, SalesOrderListResponse>
    {
        private readonly ISalesOrderRepository _salesOrderRepository;

        public SalesOrderListRequestHandler(ISalesOrderRepository salesOrderRepository)
        {
            _salesOrderRepository = salesOrderRepository;
        }

        public async Task<SalesOrderListResponse> HandleAsync(SalesOrderListRequest request, CancellationToken cancellationToken)
        {
            (IEnumerable<DeepCore.DAL.Entities.SalesOrder> items, long total) = await _salesOrderRepository.GetPagedAsync(request.Page, request.PageSize, request.OrderNumber, request.CustomerId, request.Status, cancellationToken);

            var dtoItems = items.Select(s => new SalesOrderListItemDto
            {
                Id = s.Id,
                OrderNumber = s.OrderNo,
                Status = s.Status,
                TotalAmount = s.TotalAmount
            }).ToList();

            return new SalesOrderListResponse
            {
                Success = true,
                Items = dtoItems,
                TotalCount = total
            };
        }
    }
}
