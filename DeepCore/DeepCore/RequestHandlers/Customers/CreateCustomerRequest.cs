namespace DeepCore.RequestHandlers.Customers
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        public required string Name { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
