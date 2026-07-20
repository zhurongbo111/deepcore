using DeepCore.RequestHandlers.Shared;
using System.Collections.Generic;

namespace DeepCore.RequestHandlers.Suppliers
{
    public class SupplierDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public int Status { get; set; }
    }

    public class SupplierListResponse : PagedResponse<SupplierDto>
    {
    }
}
