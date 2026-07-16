using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeepCore.DAL.Repository
{
    public class AbstractEFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public AbstractEFRepository(DeepCoreDbContext context)
        {
            DbContext = context;
            this.Table = DbContext.Set<TEntity>();
        }

        protected DbSet<TEntity> Table { get; }

        protected DeepCoreDbContext DbContext { get; }

        protected IQueryable<TEntity> TableAsNoTacking
        {
            get
            {
                return this.Table.AsNoTracking();
            }
        }

        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            DateTimeOffset now = DateTimeOffset.Now;
            entity.CreatedTime = entity.CreatedTime == default ? now : entity.CreatedTime;
            entity.UpdatedTime = entity.UpdatedTime == default ? now : entity.UpdatedTime;
            this.Table.Add(entity);
            await this.DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            entity.UpdatedTime = DateTimeOffset.Now;
            var entry = this.DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Modified;
            }

            await this.DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }
        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.DbContext.Entry(entity).State = EntityState.Deleted;

            await this.DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
