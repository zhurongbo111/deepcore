using System.ComponentModel.DataAnnotations;

namespace DeepCore.RequestHandlers.Auth
{
    public class AuthLoginRequest : IRequest<AuthLoginResponse>
    {
        [Required]
        public required string UserName { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
