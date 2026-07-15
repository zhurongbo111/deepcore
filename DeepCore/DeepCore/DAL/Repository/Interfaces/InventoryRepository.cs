using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository.Interfaces
{
    public class InventoryRepository : AbstractEFRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
