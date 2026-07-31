using System.ComponentModel.DataAnnotations;

namespace DeepCore.RequestHandlers.Auth
{
    public class AuthLoginRequest : IRequest<AuthLoginResponse>
    {
        [Required, MaxLength(50)]
        public required string UserName { get; set; }

        [Required, MaxLength(100)]
        public required string Password { get; set; }
    }
}
