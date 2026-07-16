using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.RequestHandlers.Users
{
    public class UserListRequestHandler : IRequestHandler<UserListRequest, UserListResponse>
    {
        private readonly IUserRepository _userRepository;

        public UserListRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserListResponse> HandleAsync(UserListRequest request, CancellationToken cancellationToken)
        {
            (IEnumerable<User> users, long total) = await _userRepository.GetPagedAsync(request.Page, request.PageSize, request.Name, request.Phone, null, cancellationToken);

            return new UserListResponse
            {
                Items = users.Select(u => new UserListItemDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FullName = u.RealName,
                    Status = u.Status
                }).ToList(),
                TotalCount = total
            };
        }
    }
}
