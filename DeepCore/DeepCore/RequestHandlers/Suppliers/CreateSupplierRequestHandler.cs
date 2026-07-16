using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using System.Threading;

namespace DeepCore.RequestHandlers.Suppliers
{
    public class CreateSupplierRequestHandler : IRequestHandler<CreateSupplierRequest, CreateSupplierResponse>
    {
        private readonly ISupplierRepository _supplierRepository;

        public CreateSupplierRequestHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<CreateSupplierResponse> HandleAsync(CreateSupplierRequest request, CancellationToken cancellationToken)
        {
            var supplier = new Supplier
            {
                Name = request.Name,
                ContactName = request.Contact,
                Phone = request.Phone,
                Address = request.Address,
                Remark = request.Remark ,
            };

            await _supplierRepository.InsertAsync(supplier, cancellationToken);

            return new CreateSupplierResponse
            {
                Success = true,
                Id = supplier.Id
            };
        }
    }
}
