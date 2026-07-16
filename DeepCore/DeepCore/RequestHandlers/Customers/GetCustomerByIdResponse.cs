namespace DeepCore.RequestHandlers.Customers
{
    public class GetCustomerByIdResponse : BaseResponse
    {
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Remark { get; set; }
    }
}
