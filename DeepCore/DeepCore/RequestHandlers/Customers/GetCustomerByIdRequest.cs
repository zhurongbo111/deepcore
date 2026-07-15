namespace DeepCore.RequestHandlers.Customers
{
    public class GetCustomerByIdRequest : IRequest<GetCustomerByIdResponse>
    {
        public long Id { get; set; }
    }
}
