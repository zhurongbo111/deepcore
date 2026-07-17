using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Auth
{
    public class AuthRefreshResponse : BaseResponse
    {
        public required string Token { get; set; }
    }
}
