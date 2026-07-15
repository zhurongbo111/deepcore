using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Users
{
    public class UserListRequest : PagedRequest, IRequest<UserListResponse>
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
    }
}
