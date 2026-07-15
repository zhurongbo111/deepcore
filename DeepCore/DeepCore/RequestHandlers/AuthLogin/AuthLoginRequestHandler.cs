namespace DeepCore.RequestHandlers.AuthLogin
{
    public class AuthLoginRequestHandler : IRequestHandler<AuthLoginRequest, AuthLoginResponse>
    {
        public Task<AuthLoginResponse> HandleAsync(AuthLoginRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
