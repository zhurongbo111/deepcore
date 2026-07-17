using DeepCore.RequestHandlers.Shared;
using System.Collections.Generic;

namespace DeepCore.RequestHandlers.Users
{
    public class UserListItemDto
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? RealName { get; set; }
        public string? Phone { get; set; }

        public string? Email { get; set; }
        public int Status { get; set; }
    }

    public class UserListResponse : PagedResponse<UserListItemDto>
    {
    }
}
