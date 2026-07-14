using Microsoft.EntityFrameworkCore;

namespace DeepCore.DAL.Repository
{
    public class AbstractEFRepository<TEntity> : IRepository<TEntity> where TEntity : class
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

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            this.Table.Add(entity);
            await this.DbContext.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = this.DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Modified;
            }

            await this.DbContext.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }
        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.DbContext.Entry(entity).State = EntityState.Deleted;

            await this.DbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
