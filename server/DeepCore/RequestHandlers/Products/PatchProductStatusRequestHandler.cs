using DeepCore.DAL.Repository.Interfaces;
using System.Threading;

namespace DeepCore.RequestHandlers.Products
{
    public class PatchProductStatusRequestHandler : IRequestHandler<PatchProductStatusRequest, PatchProductStatusResponse>
    {
        private readonly IProductRepository _productRepository;

        public PatchProductStatusRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PatchProductStatusResponse> HandleAsync(PatchProductStatusRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            if(product == null)
            {
                return new PatchProductStatusResponse
                {
                    Success = false,
                    Message = $"Product with ID {request.Id} not found."
                };
            }

            product.Status = request.Status;
            await _productRepository.UpdateAsync(product, cancellationToken);

            return new PatchProductStatusResponse
            {
                Success = true,
                Message = $"Product status updated successfully."
            };

        }
    }
}
