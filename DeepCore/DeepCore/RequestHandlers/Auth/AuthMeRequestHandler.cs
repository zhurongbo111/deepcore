using DeepCore.DAL.Repository.Interfaces;
using DeepCore.Services;
using System.Threading;

namespace DeepCore.RequestHandlers.Auth
{
    public class AuthMeRequestHandler : IRequestHandler<AuthMeRequest, AuthMeResponse>
    {
        private readonly ISessionContextService _sessionContextService;
        private readonly IUserRepository _userRepository;

        public AuthMeRequestHandler(ISessionContextService sessionContextService, IUserRepository userRepository)
        {
            _sessionContextService = sessionContextService;
            _userRepository = userRepository;
        }

        public async Task<AuthMeResponse> HandleAsync(AuthMeRequest request, CancellationToken cancellationToken)
        {
            var userId = _sessionContextService.GetCurrentUserId();
            if(userId == null)
            {
                return new AuthMeResponse { Success = false };
            }
            
            var user = await _userRepository.GetUserAsync(Guid.Parse(userId), cancellationToken);

            return new AuthMeResponse
            {
                Success = user != null,
                UserName = user?.UserName,
                FullName = user?.RealName,
                Status = user?.Status ?? 0
            };
        }
    }
}
