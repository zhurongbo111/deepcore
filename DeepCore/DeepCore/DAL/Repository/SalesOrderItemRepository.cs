using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository
{
    public class SalesOrderItemRepository : AbstractEFRepository<SalesOrderItem>, ISalesOrderItemRepository
    {
        public SalesOrderItemRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
