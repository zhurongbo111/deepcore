using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Auth
{
    public class AuthMeResponse : BaseResponse
    {
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public int Status { get; set; }
    }
}
