using DeepCore.DAL.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DeepCore.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IOptions<JwtTokenServiceOptions> _optionsAccessor;

        public JwtTokenService(IOptions<JwtTokenServiceOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
        }

        public string GenerateToken(User user)
        {
            var jwtSettings = _optionsAccessor.Value;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.PublicUserId.ToString()) // 唯一标识
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpireMinutes),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }

    public class JwtTokenServiceOptions
    {
        internal static readonly string SectionName = "JwtSettings";
        public string SecretKey { get; set; } = null!;

        public string Issuer { get; set; } = null!;

        public string Audience { get; set; } = null!;
        public int ExpireMinutes { get; set; } = 60;
    }
}
