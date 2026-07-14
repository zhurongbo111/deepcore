using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository
{
    public class InventoryRepository : AbstractEFRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
