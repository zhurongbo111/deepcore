using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.RequestHandlers.Users
{
    public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdResponse> HandleAsync(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            return new GetUserByIdResponse
            {
                Success = user != null,
                PublicUserId = user?.PublicUserId ?? Guid.Empty,
                UserName = user?.UserName,
                FullName = user?.RealName,
                Phone = user?.Phone,
                Email = user?.Email,
                Status = user?.Status ?? 0
            };
        }
    }
}
