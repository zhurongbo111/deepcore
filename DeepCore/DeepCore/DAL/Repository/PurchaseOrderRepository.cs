using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.DAL.Repository
{
    public class PurchaseOrderRepository : AbstractEFRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
