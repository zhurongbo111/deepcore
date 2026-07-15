using System.Collections.Generic;

namespace DeepCore.RequestHandlers.Users
{
    public class UserListItemDto
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public int Status { get; set; }
    }

    public class UserListResponse
    {
        public IEnumerable<UserListItemDto>? Items { get; set; }
        public long TotalCount { get; set; }
    }
}
