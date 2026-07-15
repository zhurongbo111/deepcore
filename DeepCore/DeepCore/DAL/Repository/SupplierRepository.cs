using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.DAL.Repository
{
    public class SupplierRepository : AbstractEFRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
