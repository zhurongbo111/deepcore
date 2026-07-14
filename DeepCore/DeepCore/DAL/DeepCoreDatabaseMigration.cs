using Microsoft.EntityFrameworkCore;

namespace DeepCore.DAL
{
    public class DeepCoreDatabaseMigration : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public DeepCoreDatabaseMigration(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<DeepCoreDatabaseMigration>>();
                logger.LogInformation("Start Migrate DBContext {type}, {datetime}", typeof(DeepCoreDbContext).FullName, DateTime.UtcNow.ToString("O"));
                await scope.ServiceProvider.GetRequiredService<DeepCoreDbContext>().Database.MigrateAsync().ConfigureAwait(false);
                logger.LogInformation("Finish Migrate DBContext {type}, {datetime}", typeof(DeepCoreDbContext).FullName, DateTime.UtcNow.ToString("O"));
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
