using System.Collections.Generic;

namespace DeepCore.RequestHandlers.Customers
{
    public class CustomerDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
    }

    public class CustomerListResponse
    {
        public IEnumerable<CustomerDto>? Items { get; set; }
        public long TotalCount { get; set; }
    }
}
