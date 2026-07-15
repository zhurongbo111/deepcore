namespace DeepCore.RequestHandlers.Customers
{
    public class GetCustomerByIdResponse
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
