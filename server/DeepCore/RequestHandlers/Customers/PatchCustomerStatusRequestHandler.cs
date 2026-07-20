using DeepCore.DAL.Repository.Interfaces;
using System.Threading;

namespace DeepCore.RequestHandlers.Customers
{

    public class PatchCustomerStatusRequestHandler : IRequestHandler<PatchCustomerStatusRequest, PatchCustomerStatusResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public PatchCustomerStatusRequestHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<PatchCustomerStatusResponse> HandleAsync(PatchCustomerStatusRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);

            if (customer == null)
            {
                return new PatchCustomerStatusResponse
                {
                    Success = false,
                    Message = $"Customer with ID {request.Id} not found."
                };
            }

            customer.Status = request.Status;
            await _customerRepository.UpdateAsync(customer, cancellationToken);

            return new PatchCustomerStatusResponse
            {
                Success = true,
                Message = "Customer status updated successfully."
            };

        }
    }
}
