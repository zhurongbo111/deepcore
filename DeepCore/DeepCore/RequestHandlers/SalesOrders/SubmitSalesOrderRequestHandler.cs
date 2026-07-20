namespace DeepCore.RequestHandlers.SalesOrders
{
    using DeepCore.DAL.Repository.Interfaces;
    using DeepCore.DAL.Entities;

    public class SubmitSalesOrderRequestHandler : IRequestHandler<SubmitSalesOrderRequest, SubmitSalesOrderResponse>
    {
        private readonly ISalesOrderRepository _salesOrderRepository;

        public SubmitSalesOrderRequestHandler(ISalesOrderRepository salesOrderRepository)
        {
            _salesOrderRepository = salesOrderRepository;
        }

        public async Task<SubmitSalesOrderResponse> HandleAsync(SubmitSalesOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _salesOrderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (order == null || order.Status != SalesOrderStatus.Draft)
            {
                return new SubmitSalesOrderResponse { Success = false };
            }

            order.Status = SalesOrderStatus.Submitted; // submitted
            if (order.OrderDate == default)
            {
                order.OrderDate = DateTimeOffset.UtcNow;
            }

            await _salesOrderRepository.UpdateAsync(order, cancellationToken);

            return new SubmitSalesOrderResponse { Success = true };
        }
    }
}
