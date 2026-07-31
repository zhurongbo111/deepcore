using System.ComponentModel.DataAnnotations;

namespace DeepCore.RequestHandlers.Users
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        [Required, MaxLength(50)]
        public required string UserName { get; set; }
        [MaxLength(100)]
        public string? FullName { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
    }
}
