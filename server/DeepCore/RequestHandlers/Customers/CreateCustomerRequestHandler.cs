using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using System.Threading;

namespace DeepCore.RequestHandlers.Customers
{
    public class CreateCustomerRequestHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerRequestHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CreateCustomerResponse> HandleAsync(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Name = request.Name,
                ContactName = request.Contact,
                Phone = request.Phone,
                Address = request.Address,
                Remark = request.Remark
            };

            await _customerRepository.InsertAsync(customer, cancellationToken);

            return new CreateCustomerResponse
            {
                Success = true,
                Id = customer.Id
            };
        }
    }
}
