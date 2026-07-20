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

        public async Task<IWork> BeginWorkAsync(CancellationToken cancellationToken)
        {
            var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            return new EfCoreWork(transaction);
        }

    }

    internal class EfCoreWork : IWork
    {
        private readonly IDbContextTransaction _dbContextTransaction;

        internal EfCoreWork(IDbContextTransaction dbContextTransaction)
        {
            _dbContextTransaction = dbContextTransaction.ThrowIfNull(nameof(dbContextTransaction));
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
            _dbContextTransaction.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContextTransaction.DisposeAsync();
        }
    }
}
