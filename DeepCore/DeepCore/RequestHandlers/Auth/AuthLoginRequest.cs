namespace DeepCore.RequestHandlers.Auth
{
    public class AuthLoginRequest : IRequest<AuthLoginResponse>
    {
        public required string UserName { get; set; }

        public required string PasswordHash { get; set; }
    }
}
