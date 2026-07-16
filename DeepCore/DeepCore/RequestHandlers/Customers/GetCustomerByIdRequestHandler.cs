using DeepCore.DAL.Repository.Interfaces;
using System.Threading;

namespace DeepCore.RequestHandlers.Customers
{
    public class GetCustomerByIdRequestHandler : IRequestHandler<GetCustomerByIdRequest, GetCustomerByIdResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdRequestHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GetCustomerByIdResponse> HandleAsync(GetCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);

            return new GetCustomerByIdResponse
            {
                Success = customer != null,
                Name = customer?.Name,
                Contact = customer?.ContactName,
                Phone = customer?.Phone,
                Address = customer?.Address,
                Remark = customer?.Remark,
            };
        }
    }
}
