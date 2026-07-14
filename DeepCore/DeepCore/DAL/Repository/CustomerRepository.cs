using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository
{
    public class CustomerRepository : AbstractEFRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
