using DeepCore.DAL.Repository.Interfaces;
using System.Threading;

namespace DeepCore.RequestHandlers.Customers
{
    public class UpdateCustomerRequestHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerRequestHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<UpdateCustomerResponse> HandleAsync(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);

            if (customer == null)
            {
                return new UpdateCustomerResponse
                {
                    Success = false,
                    Message = "Customer is not found."
                };
            }

            customer.Name = request.Name ?? customer.Name;
            customer.ContactName = request.Contact ?? customer.ContactName;
            customer.Phone = request.Phone ?? customer.Phone;
            customer.Address = request.Address ?? customer.Address;
            customer.Remark = request.Remark ?? customer.Remark;

            await _customerRepository.UpdateAsync(customer, cancellationToken);

            return new UpdateCustomerResponse
            {
                Success = true,
                Message = "Customer updated successfully."
            };
        }
    }
}
