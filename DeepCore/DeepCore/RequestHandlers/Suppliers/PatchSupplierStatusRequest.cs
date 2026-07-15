namespace DeepCore.RequestHandlers.Suppliers
{
    public class PatchSupplierStatusRequest : IRequest<PatchSupplierStatusResponse>
    {
        public long Id { get; set; }
        public int Status { get; set; }
    }
}
