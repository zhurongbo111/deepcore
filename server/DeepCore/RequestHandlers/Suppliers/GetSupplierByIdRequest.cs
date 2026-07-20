namespace DeepCore.RequestHandlers.Suppliers
{
    public class GetSupplierByIdRequest : IRequest<GetSupplierByIdResponse>
    {
        public long Id { get; set; }
    }
}
