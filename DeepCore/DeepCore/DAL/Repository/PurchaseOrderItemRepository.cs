using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository
{
    public class PurchaseOrderItemRepository : AbstractEFRepository<PurchaseOrderItem>, IPurchaseOrderItemRepository
    {
        public PurchaseOrderItemRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
