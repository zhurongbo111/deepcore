namespace DeepCore.RequestHandlers.Auth
{
    public class AuthPasswordChangeRequest : IRequest<AuthPasswordChangeResponse>
    {
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
    }
}
