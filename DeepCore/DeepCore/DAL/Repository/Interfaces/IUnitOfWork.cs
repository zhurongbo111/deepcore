namespace DeepCore.DAL.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        Task<IWork> BeginWorkAsync(bool autoCommit, CancellationToken cancellationToken);
    }
}
