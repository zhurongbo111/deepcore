using System.Threading;

namespace DeepCore.RequestHandlers.Auth
{
    public class AuthPasswordChangeRequestHandler : IRequestHandler<AuthPasswordChangeRequest, AuthPasswordChangeResponse>
    {
        public Task<AuthPasswordChangeResponse> HandleAsync(AuthPasswordChangeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
