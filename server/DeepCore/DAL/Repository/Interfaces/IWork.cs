namespace DeepCore.DAL.Repository.Interfaces
{
    public interface IWork : IDisposable, IAsyncDisposable
    {
        Task CommitAsync(CancellationToken cancellationToken);

        Task RollbackAsync(CancellationToken cancellationToken);
    }
}
