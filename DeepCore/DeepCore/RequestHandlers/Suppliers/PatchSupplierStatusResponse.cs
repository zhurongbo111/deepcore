namespace DeepCore.RequestHandlers.Suppliers
{
    public class PatchSupplierStatusResponse : BaseResponse
    {
        public long Id { get; set; }
        public int Status { get; set; }
    }
}
