using PrimeWeb.Core.Data;
using PrimeWeb.Data;
using PrimeWeb.Data.Identity;

namespace PrimeWeb.Repo.Implementation
{
    public class UserRepository : Abstract.Repository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork<DBContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
