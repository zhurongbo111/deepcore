using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using DeepCore.RequestHandlers.Shared;
using System.Threading;
using System.Linq;

namespace DeepCore.RequestHandlers.Customers
{
    public class CustomerListRequestHandler : IRequestHandler<CustomerListRequest, CustomerListResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerListRequestHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerListResponse> HandleAsync(CustomerListRequest request, CancellationToken cancellationToken)
        {
            (IEnumerable<Customer> customers, long total) = await _customerRepository.GetPagedAsync(request.Page, request.PageSize, request.Name, request.Contact, request.Phone, null, cancellationToken);

            return new CustomerListResponse
            {
                Items = customers.Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Contact = c.ContactName,
                    Phone = c.Phone,
                }).ToList(),
                TotalCount = total
            };
        }
    }
}
