using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.DAL.Repository
{
    public class ProductRepository : AbstractEFRepository<Product>, IProductRepository
    {
        public ProductRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
