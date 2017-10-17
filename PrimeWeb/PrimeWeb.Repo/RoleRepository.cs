using PrimeWeb.Core.Data;
using PrimeWeb.Data;
using PrimeWeb.Data.Identity;

namespace PrimeWeb.Repo
{
    public class RoleRepository : Abstract.Repository<Role>
    {
        public RoleRepository(IUnitOfWork<DBContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
