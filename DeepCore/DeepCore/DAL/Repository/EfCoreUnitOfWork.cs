using DeepCore.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace DeepCore.DAL.Repository
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly DeepCoreDbContext _context;
        public EfCoreUnitOfWork(DeepCoreDbContext context)
        {
            _context = context;
        }

        public async Task<IWork> BeginWorkAsync(bool autoCommit, CancellationToken cancellationToken)
        {
            var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            return new EfCoreWork(transaction, autoCommit);
        }

    }

    internal class EfCoreWork : IWork
    {
        private readonly IDbContextTransaction _dbContextTransaction;
        private readonly bool _autoCommit;

        internal EfCoreWork(IDbContextTransaction dbContextTransaction, bool autoCommit)
        {
            _dbContextTransaction = dbContextTransaction.ThrowIfNull(nameof(dbContextTransaction));
            _autoCommit = autoCommit;
        }

        public Task CommitAsync(CancellationToken cancellationToken)
        {
            return _dbContextTransaction.CommitAsync(cancellationToken);
        }

        public Task RollbackAsync(CancellationToken cancellationToken)
        {
            return _dbContextTransaction.RollbackAsync(cancellationToken);
        }

        public void Dispose()
        {
            if (_autoCommit)
            {
                _dbContextTransaction.Commit();
            }

            _dbContextTransaction.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            if (_dbContextTransaction != null)
            {
                if (_autoCommit)
                {
                    await _dbContextTransaction.CommitAsync();
                }

                await _dbContextTransaction.DisposeAsync();
            }
        }
    }
}
