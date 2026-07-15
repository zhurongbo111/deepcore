namespace DeepCore.RequestHandlers.Users
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        public Task<CreateUserResponse> HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        public Task<UpdateUserResponse> HandleAsync(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class PatchUserStatusRequestHandler : IRequestHandler<PatchUserStatusRequest, PatchUserStatusResponse>
    {
        public Task<PatchUserStatusResponse> HandleAsync(PatchUserStatusRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class UserListRequestHandler : IRequestHandler<UserListRequest, UserListResponse>
    {
        public Task<UserListResponse> HandleAsync(UserListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public long Id { get; set; }
    }

    public class GetUserByIdResponse
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int Status { get; set; }
    }

    public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        public Task<GetUserByIdResponse> HandleAsync(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
