using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Repository
{
    public class UserRepository : AbstractEFRepository<User>, IUserRepository
    {
        public UserRepository(DeepCoreDbContext context) : base(context)
        {
        }
    }
}
