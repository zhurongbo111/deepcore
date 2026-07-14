using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository
{
    public class SupplierRepository : AbstractEFRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
