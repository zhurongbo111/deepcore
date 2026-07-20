namespace DeepCore.RequestHandlers
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;
        private static readonly Dictionary<Type, Type> _handlerTypes = new Dictionary<Type, Type>();
        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
        {
            var handlerType = GetHandlerType(request);
            if (handlerType == null)
            {
                throw new InvalidOperationException($"No handler registered for request type {request.GetType().Name}");
            }

            dynamic handler = _serviceProvider.GetService(handlerType) ?? throw new Exception($"No registeration for request handler type {handlerType.Name}");

            return await handler.HandleAsync((dynamic)request, cancellationToken);
        }

        private Type GetHandlerType<TResponse>(IRequest<TResponse> request)
        {
            var requestType = request.GetType();
            if (!_handlerTypes.TryGetValue(requestType, out var handlerType))
            {
                var requestInterfaceType = requestType.GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequest<>));
                if(requestInterfaceType == null)
                {
                    throw new InvalidOperationException($"Request type {requestType.Name} does not implement IRequest<TResponse>");
                }

                Type responseType = requestInterfaceType.GetGenericArguments()[0];

                Type requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);

                _handlerTypes.TryAdd(requestType, requestHandlerType);
                return requestHandlerType;
            }
            else
            {
                return handlerType;
            }
        }
    }
}
