using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Users
{
    public class GetUserByIdResponse : BaseResponse
    {
        public Guid PublicUserId { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int Status { get; set; }
    }
}
