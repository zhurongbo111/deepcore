using NUlid;

namespace DeepCore.Services
{
    public class CodeGeneraterService : ICodeGeneraterService
    {
        public Task<string> GeneratePurchaseOrderCodeAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var ulid = Ulid.NewUlid();

            return Task.FromResult($"PO{DateTime.UtcNow.AddHours(8).ToString("yyyyMMdd")}{ulid}");
        }

        public Task<string> GenerateSalesOrderCodeAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var ulid = Ulid.NewUlid();

            return Task.FromResult($"SO{DateTime.UtcNow.AddHours(8).ToString("yyyyMMdd")}{ulid}");
        }
    }
}
