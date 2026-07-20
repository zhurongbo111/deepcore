namespace DeepCore.RequestHandlers.SalesOrders
{
    using DeepCore.DAL.Repository.Interfaces;
    using System.Linq;

    public class GetSalesOrderByIdRequestHandler : IRequestHandler<GetSalesOrderByIdRequest, GetSalesOrderByIdResponse>
    {
        private readonly ISalesOrderRepository _salesOrderRepository;

        public GetSalesOrderByIdRequestHandler(ISalesOrderRepository salesOrderRepository)
        {
            _salesOrderRepository = salesOrderRepository;
        }

        public async Task<GetSalesOrderByIdResponse> HandleAsync(GetSalesOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var order = await _salesOrderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (order == null)
            {
                return new GetSalesOrderByIdResponse { Success = false };
            }

            var items = order.Items.Select(i => new SalesOrderDetailItemDto
            {
                ProductId = i.ProductId,
                ProductName = i.Product?.Name,
                Quantity = (int)i.Quantity,
                UnitPrice = i.Price,
                Amount = i.Amount ?? 0m
            }).ToList();

            return new GetSalesOrderByIdResponse
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
