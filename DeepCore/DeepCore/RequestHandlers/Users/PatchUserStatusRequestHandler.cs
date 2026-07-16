using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.RequestHandlers.Users
{
    public class PatchUserStatusRequestHandler : IRequestHandler<PatchUserStatusRequest, PatchUserStatusResponse>
    {
        private readonly IUserRepository _userRepository;

        public PatchUserStatusRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PatchUserStatusResponse> HandleAsync(PatchUserStatusRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (user == null)
            {
                return new PatchUserStatusResponse
                {
                    Success = false,
                    Message = $"User with ID {request.Id} not found."
                };
            }

            user.Status = request.Status;
            await _userRepository.UpdateAsync(user, cancellationToken);

            return new PatchUserStatusResponse
            {
                Success = true,
                Message = "User status updated successfully."
            };
        }
    }
}
