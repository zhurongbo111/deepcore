using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using DeepCore.Services;
using Microsoft.AspNetCore.Identity;

namespace DeepCore.RequestHandlers.Auth
{
    public class AuthLoginRequestHandler : IRequestHandler<AuthLoginRequest, AuthLoginResponse>
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthLoginRequestHandler(IJwtTokenService jwtTokenService, IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _jwtTokenService = jwtTokenService;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthLoginResponse> HandleAsync(AuthLoginRequest request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetUserByUsernameAsync(request.UserName, cancellationToken);

            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) != PasswordVerificationResult.Success)
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
