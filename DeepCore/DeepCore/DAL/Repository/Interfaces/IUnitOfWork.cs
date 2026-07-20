namespace DeepCore.DAL.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        Task<IWork> BeginWorkAsync(CancellationToken cancellationToken);
    }
}
