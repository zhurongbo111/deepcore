using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.DAL.Repository
{
    public class PurchaseOrderItemRepository : AbstractEFRepository<PurchaseOrderItem>, IPurchaseOrderItemRepository
    {
        public PurchaseOrderItemRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
