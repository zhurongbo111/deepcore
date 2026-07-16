namespace DeepCore.DAL.Repository.Interfaces
{
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
