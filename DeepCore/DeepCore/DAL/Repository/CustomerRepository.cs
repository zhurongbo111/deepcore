using DeepCore.DAL.Entities;
using DeepCore.DAL.Repository.Interfaces;

namespace DeepCore.DAL.Repository
{
    public class CustomerRepository : AbstractEFRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
