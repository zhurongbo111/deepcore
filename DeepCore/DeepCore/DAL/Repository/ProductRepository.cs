using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository
{
    public class ProductRepository : AbstractEFRepository<Product>, IProductRepository
    {
        public ProductRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
