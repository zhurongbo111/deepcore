using System.Threading;

namespace DeepCore.RequestHandlers.Auth
{
    public class AuthMeRequestHandler : IRequestHandler<AuthMeRequest, AuthMeResponse>
    {
        public Task<AuthMeResponse> HandleAsync(AuthMeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
