using DeepCore.RequestHandlers.AuthLogin;

namespace DeepCore.RequestHandlers
{
    public static class RequestHandlerServiceCollectionExtension
    {
        public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
        {
            services.AddTransient<IMediator, Mediator>();
            services.AddScoped<IRequestHandler<AuthLoginRequest,AuthLoginResponse>, AuthLoginRequestHandler>();
            return services;
        }
    }
}
