using DeepCore.DAL.Repository.Interfaces;
using DeepCore.Services;

namespace DeepCore.RequestHandlers.Auth
{
    public class AuthLoginRequestHandler : IRequestHandler<AuthLoginRequest, AuthLoginResponse>
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUserRepository _userRepository;

        public AuthLoginRequestHandler(IJwtTokenService jwtTokenService, IUserRepository userRepository)
        {
            _jwtTokenService = jwtTokenService;
            _userRepository = userRepository;
        }

        public async Task<AuthLoginResponse> HandleAsync(AuthLoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.UserName, request.PasswordHash, cancellationToken);

            if (user == null)
            {
                return new AuthLoginResponse
                {
                    Success = false,
                    Message = "Invalid username or password."
                };
            }

            var token = _jwtTokenService.GenerateToken(user);

            return new AuthLoginResponse
            {
                Success = true,
                Message = "Login successful.",
                Token = token
            };
        }
    }
}
