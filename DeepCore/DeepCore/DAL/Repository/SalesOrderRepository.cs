using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.DAL.Repository
{
    public class SalesOrderRepository : AbstractEFRepository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
