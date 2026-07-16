namespace DeepCore.RequestHandlers.Suppliers
{
    public class GetSupplierByIdResponse : BaseResponse
    {
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Remark { get; set; }
        public int Status { get; set; }
    }
}
