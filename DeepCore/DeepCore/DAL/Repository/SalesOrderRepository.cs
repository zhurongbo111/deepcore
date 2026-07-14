using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository
{
    public class SalesOrderRepository : AbstractEFRepository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
