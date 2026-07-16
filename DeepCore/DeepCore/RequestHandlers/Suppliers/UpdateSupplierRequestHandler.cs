using DeepCore.DAL.Repository.Interfaces;
using System.Threading;

namespace DeepCore.RequestHandlers.Suppliers
{
    public class UpdateSupplierRequestHandler : IRequestHandler<UpdateSupplierRequest, UpdateSupplierResponse>
    {
        private readonly ISupplierRepository _supplierRepository;

        public UpdateSupplierRequestHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<UpdateSupplierResponse> HandleAsync(UpdateSupplierRequest request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.Id, cancellationToken);

            if (supplier == null)
            {
                return new UpdateSupplierResponse
                {
                    Success = false,
                    Message = "Supplier is not found."
                };
            }

            supplier.Name = request.Name ?? supplier.Name;
            supplier.ContactName = request.Contact ?? supplier.ContactName;
            supplier.Phone = request.Phone ?? supplier.Phone;
            supplier.Address = request.Address ?? supplier.Address;
            supplier.Remark = request.Remark ?? supplier.Remark;

            await _supplierRepository.UpdateAsync(supplier, cancellationToken);

            return new UpdateSupplierResponse
            {
                Success = true,
                Message = "Supplier updated successfully."
            };
        }
    }
}
