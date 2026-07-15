namespace DeepCore.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.Configure<JwtTokenServiceOptions>(configuration.GetSection(JwtTokenServiceOptions.SectionName));
            return services;
        }
    }
}
