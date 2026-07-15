using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.DAL.Repository
{
    public class SalesOrderItemRepository : AbstractEFRepository<SalesOrderItem>, ISalesOrderItemRepository
    {
        public SalesOrderItemRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
