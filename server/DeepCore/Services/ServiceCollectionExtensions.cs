using DeepCore.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DeepCore.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.Configure<JwtTokenServiceOptions>(configuration.GetSection(JwtTokenServiceOptions.SectionName));
            services.TryAddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));
            services.AddScoped<ISessionContextService, SessionContextService>();
            services.AddSingleton<ICodeGeneraterService, CodeGeneraterService>();
            return services;
        }
    }
}
