namespace DeepCore.RequestHandlers.Customers
{
    public class PatchCustomerStatusResponse : BaseResponse
    {
        public long Id { get; set; }
        public int Status { get; set; }
    }
}
