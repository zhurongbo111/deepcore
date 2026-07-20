namespace DeepCore.RequestHandlers.SalesOrders
{
    using DeepCore.DAL.Entities;
    using DeepCore.DAL.Repository.Interfaces;
    using DeepCore.Services;
    using System.Linq;

    public class CreateSalesOrderRequestHandler : IRequestHandler<CreateSalesOrderRequest, CreateSalesOrderResponse>
    {
        private readonly ISalesOrderRepository _salesOrderRepository;
        private readonly ICodeGeneraterService _codeGeneraterService;

        public CreateSalesOrderRequestHandler(ISalesOrderRepository salesOrderRepository, ICodeGeneraterService codeGeneraterService)
        {
            _salesOrderRepository = salesOrderRepository;
            _codeGeneraterService = codeGeneraterService;
        }

        public async Task<CreateSalesOrderResponse> HandleAsync(CreateSalesOrderRequest request, CancellationToken cancellationToken)
        {
            var order = new SalesOrder
            {
                CustomerId = request.CustomerId,
                Status = (SalesOrderStatus)request.Status,
                OrderDate = DateTimeOffset.UtcNow,
                OrderNo = await _codeGeneraterService.GenerateSalesOrderCodeAsync(cancellationToken),
                Items = request.Items?.Select(i => new SalesOrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Price = i.UnitPrice,
                    Amount = i.Amount
                }).ToList() ?? new List<SalesOrderItem>()
            };

            order.TotalAmount = order.Items.Sum(x => x.Amount ?? 0m);

            await _salesOrderRepository.InsertAsync(order, cancellationToken);

            return new CreateSalesOrderResponse { Success = true };
        }
    }
}
