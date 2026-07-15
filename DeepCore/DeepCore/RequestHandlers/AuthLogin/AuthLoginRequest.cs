namespace DeepCore.RequestHandlers.AuthLogin
{
    public class AuthLoginRequest : IRequest<AuthLoginResponse>
    {
        public required string UserName { get; set; }

        public required string PasswordHash { get; set; }
    }
}
