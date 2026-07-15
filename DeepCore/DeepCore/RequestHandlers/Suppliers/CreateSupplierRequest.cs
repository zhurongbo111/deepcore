namespace DeepCore.RequestHandlers.Suppliers
{
    public class CreateSupplierRequest : IRequest<CreateSupplierResponse>
    {
        public required string Name { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
