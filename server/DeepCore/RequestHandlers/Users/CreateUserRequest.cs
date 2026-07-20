using System.ComponentModel.DataAnnotations;

namespace DeepCore.RequestHandlers.Users
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        [Required]
        public required string UserName { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
