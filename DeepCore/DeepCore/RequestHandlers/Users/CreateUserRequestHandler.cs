using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DeepCore.RequestHandlers.Users
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public CreateUserRequestHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<CreateUserResponse> HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                PublicUserId = Guid.NewGuid(),
                UserName = request.UserName,
                RealName = request.FullName,
                Phone = request.Phone,
                Email = request.Email
            };

            // default password
            user.PasswordHash = _passwordHasher.HashPassword(user, "123456");

            await _userRepository.InsertAsync(user, cancellationToken);

            return new CreateUserResponse { Success = true, Id = user.Id };
        }
    }
}
