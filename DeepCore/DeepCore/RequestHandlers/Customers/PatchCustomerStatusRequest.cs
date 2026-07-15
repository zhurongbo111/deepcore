namespace DeepCore.RequestHandlers.Customers
{
    public class PatchCustomerStatusRequest : IRequest<PatchCustomerStatusResponse>
    {
        public long Id { get; set; }
        public int Status { get; set; }
    }
}
