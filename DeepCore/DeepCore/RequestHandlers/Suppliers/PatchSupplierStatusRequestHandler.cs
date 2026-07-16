using DeepCore.DAL.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace DeepCore.RequestHandlers.Suppliers
{
    public class PatchSupplierStatusRequestHandler : IRequestHandler<PatchSupplierStatusRequest, PatchSupplierStatusResponse>
    {
        private readonly ISupplierRepository _supplierRepository;

        public PatchSupplierStatusRequestHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<PatchSupplierStatusResponse> HandleAsync(PatchSupplierStatusRequest request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.Id, cancellationToken);

            if (supplier == null)
            {
                return new PatchSupplierStatusResponse
                {
                    Success = false,
                    Message = $"Supplier with ID {request.Id} not found."
                };
            }

            supplier.Status = request.Status;
            await _supplierRepository.UpdateAsync(supplier, cancellationToken);

            return new PatchSupplierStatusResponse
            {
                Success = true,
                Message = "Supplier status updated successfully."
            };
        }
    }
}
