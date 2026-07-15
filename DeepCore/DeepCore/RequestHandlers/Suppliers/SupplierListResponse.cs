using System.Collections.Generic;

namespace DeepCore.RequestHandlers.Suppliers
{
    public class SupplierDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
    }

    public class SupplierListResponse
    {
        public IEnumerable<SupplierDto>? Items { get; set; }
        public long TotalCount { get; set; }
    }
}
