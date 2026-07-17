using DeepCore.DAL.Repository.Interfaces;
using DeepCore.Services;

namespace DeepCore.RequestHandlers.Auth
{
    public class AuthRefreshRequestHandler : IRequestHandler<AuthRefreshRequest, AuthRefreshResponse>
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly ISessionContextService _sessionContextService;
        private readonly IUserRepository _userRepository;

        public AuthRefreshRequestHandler(IJwtTokenService jwtTokenService, ISessionContextService sessionContextService, IUserRepository userRepository)
        {
            _jwtTokenService = jwtTokenService;
            _sessionContextService = sessionContextService;
            _userRepository = userRepository;
        }

        public async Task<AuthRefreshResponse> HandleAsync(AuthRefreshRequest request, CancellationToken cancellationToken)
        {
            var userId = _sessionContextService.GetCurrentUserId();
            var user = await _userRepository.GetUserByPublicUserIdAsync(Guid.Parse(userId!), cancellationToken);
            var token = _jwtTokenService.GenerateToken(user!);
            return new AuthRefreshResponse
            {
                Success = true,
                Token = token
            };
        }
    }
}
