namespace DeepCore.RequestHandlers.Users
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public long Id { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
