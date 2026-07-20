using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Auth
{
    public class AuthLoginResponse : BaseResponse
    {
        public string? Token { get; set; }
    }
}
