using System.ComponentModel.DataAnnotations;

namespace DeepCore.RequestHandlers.Auth
{
    public class AuthPasswordChangeRequest : IRequest<AuthPasswordChangeResponse>
    {
        [Required, MaxLength(50)]
        public required string UserName { get; set; }
        [Required, MaxLength(200)]
        public required string PasswordHash { get; set; }
    }
}
