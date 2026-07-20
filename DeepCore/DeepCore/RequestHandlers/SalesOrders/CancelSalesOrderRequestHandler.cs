namespace DeepCore.RequestHandlers.SalesOrders
{
    using DeepCore.DAL.Repository.Interfaces;
    using DeepCore.DAL.Entities;

    public class CancelSalesOrderRequestHandler : IRequestHandler<CancelSalesOrderRequest, CancelSalesOrderResponse>
    {
        private readonly ISalesOrderRepository _salesOrderRepository;

        public CancelSalesOrderRequestHandler(ISalesOrderRepository salesOrderRepository)
        {
            _salesOrderRepository = salesOrderRepository;
        }

        public async Task<CancelSalesOrderResponse> HandleAsync(CancelSalesOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _salesOrderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (order == null)
            {
                return new CancelSalesOrderResponse { Id = request.Id };
            }

            order.Status = SalesOrderStatus.Canceled; // canceled
            await _salesOrderRepository.UpdateAsync(order, cancellationToken);

            return new CancelSalesOrderResponse { Id = order.Id };
        }
    }
}
