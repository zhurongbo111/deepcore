using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.RequestHandlers.Users
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateUserResponse> HandleAsync(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (user == null)
            {
                return new UpdateUserResponse
                {
                    Success = false,
                    Message = "User is not found."
                };
            }

            user.RealName = request.FullName ?? user.RealName;
            user.Phone = request.Phone ?? user.Phone;
            user.Email = request.Email ?? user.Email;

            await _userRepository.UpdateAsync(user, cancellationToken);

            return new UpdateUserResponse
            {
                Success = true,
                Message = "User updated successfully."
            };
        }
    }
}
