using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository
{
    public class PurchaseOrderRepository : AbstractEFRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
