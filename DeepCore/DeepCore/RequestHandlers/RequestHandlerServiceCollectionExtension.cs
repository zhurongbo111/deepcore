using DeepCore.RequestHandlers.Auth;

namespace DeepCore.RequestHandlers
{
    public static class RequestHandlerServiceCollectionExtension
    {
        public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
        {
            services.AddTransient<IMediator, Mediator>();
            services.RegisterRequestHandlers();
            return services;
        }

        private static void RegisterRequestHandlers(this IServiceCollection services)
        {
            var types = typeof(RequestHandlerServiceCollectionExtension).Assembly.GetTypes();
            var handlerTypes = types
                    .Where(type => type.GetInterfaces()
                        .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                    .ToList();
            foreach (var handlerType in handlerTypes)
            {
                var interfaceType = handlerType.GetInterfaces()
                    .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));
                services.AddTransient(interfaceType, handlerType);
            }
        }
    }
}
