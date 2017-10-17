using PrimeWeb.Core.Data;
using PrimeWeb.Data;
using PrimeWeb.Data.Identity;

namespace PrimeWeb.Repo
{
    public class UserRepository : Abstract.Repository<User>
    {
        public UserRepository(IUnitOfWork<DBContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
