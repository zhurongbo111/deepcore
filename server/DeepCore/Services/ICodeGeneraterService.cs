namespace DeepCore.Services
{
    public interface ICodeGeneraterService
    {
        Task<string> GeneratePurchaseOrderCodeAsync(CancellationToken cancellationToken);

        Task<string> GenerateSalesOrderCodeAsync(CancellationToken cancellationToken);
    }
}
