namespace DeepCore.RequestHandlers.Auth
{
    public class AuthLoginRequestHandler : IRequestHandler<AuthLoginRequest, AuthLoginResponse>
    {
        public Task<AuthLoginResponse> HandleAsync(AuthLoginRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
