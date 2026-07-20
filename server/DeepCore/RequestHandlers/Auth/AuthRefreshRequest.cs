using System.ComponentModel.DataAnnotations;

namespace DeepCore.RequestHandlers.Auth
{
    public class AuthRefreshRequest : IRequest<AuthRefreshResponse>
    {
        [Required]
        public required string Token { get; set; }
    }
}
