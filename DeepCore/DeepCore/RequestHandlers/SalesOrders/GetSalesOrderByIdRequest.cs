namespace DeepCore.RequestHandlers.SalesOrders
{
    public class GetSalesOrderByIdRequest : IRequest<GetSalesOrderByIdResponse>
    {
        public long Id { get; set; }
    }
}
