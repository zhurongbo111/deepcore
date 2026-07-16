using DeepCore.DAL.Repository.Interfaces;
using System.Threading;

namespace DeepCore.RequestHandlers.Suppliers
{
    public class GetSupplierByIdRequestHandler : IRequestHandler<GetSupplierByIdRequest, GetSupplierByIdResponse>
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetSupplierByIdRequestHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<GetSupplierByIdResponse> HandleAsync(GetSupplierByIdRequest request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.Id, cancellationToken);

            return new GetSupplierByIdResponse
            {
                Success = supplier != null,
                Name = supplier?.Name,
                Contact = supplier?.ContactName,
                Phone = supplier?.Phone,
                Address = supplier?.Address,
                Remark = supplier?.Remark,
                Status = supplier?.Status ?? 0
            };
        }
    }
}
