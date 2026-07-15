namespace DeepCore.RequestHandlers.Users
{
    public class PatchUserStatusRequest : IRequest<PatchUserStatusResponse>
    {
        public long Id { get; set; }
        public int Status { get; set; }
    }
}
