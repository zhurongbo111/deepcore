using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using DeepCore.RequestHandlers.Shared;
using System.Threading;
using System.Linq;

namespace DeepCore.RequestHandlers.Suppliers
{
    public class SupplierListRequestHandler : IRequestHandler<SupplierListRequest, SupplierListResponse>
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierListRequestHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<SupplierListResponse> HandleAsync(SupplierListRequest request, CancellationToken cancellationToken)
        {
            (IEnumerable<Supplier> suppliers, long total) = await _supplierRepository.GetPagedAsync(request.Page, request.PageSize, request.Name, request.Contact, request.Phone, null, cancellationToken);

            return new SupplierListResponse
            {
                Success = true,
                Items = suppliers.Select(s => new SupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Contact = s.ContactName,
                    Phone = s.Phone,
                    Status = s.Status,
                }).ToList(),
                TotalCount = total
            };
        }
    }
}
