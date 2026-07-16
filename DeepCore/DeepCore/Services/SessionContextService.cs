using System.IdentityModel.Tokens.Jwt;

namespace DeepCore.Services
{
    public class SessionContextService : ISessionContextService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public SessionContextService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string? GetCurrentUserId()
        {
            var httpContent = _contextAccessor.HttpContext;
            if(httpContent != null)
            {
                var subClaim = httpContent.User?.FindFirst(JwtRegisteredClaimNames.Sub);
                if(subClaim != null)
                {
                    return subClaim.Value;
                }
            }
            
            return null;
        }
    }
}
