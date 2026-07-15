namespace DeepCore.RequestHandlers.Users
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public required string UserName { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
