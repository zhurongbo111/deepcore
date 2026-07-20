using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Users
{
    public class PatchUserStatusResponse : BaseResponse
    {
        public long Id { get; set; }
        public int Status { get; set; }
    }
}
