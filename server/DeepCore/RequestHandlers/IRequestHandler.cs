namespace DeepCore.RequestHandlers
{
    public interface IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }

    public interface IRequestHandler
    {
        Task<object> SendAsync(object request, CancellationToken cancellationToken);
    }

    public interface IRequest<TResponse>
    {
    }
}
