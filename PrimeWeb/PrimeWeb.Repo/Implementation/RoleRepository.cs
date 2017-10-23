using PrimeWeb.Core.Data;
using PrimeWeb.Data;
using PrimeWeb.Data.Identity;

namespace PrimeWeb.Repo.Implementation
{
    public class RoleRepository : Abstract.Repository<Role>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork<DBContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
