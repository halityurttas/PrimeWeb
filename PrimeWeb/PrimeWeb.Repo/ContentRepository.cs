using PrimeWeb.Core.Data;
using PrimeWeb.Data;
using PrimeWeb.Data.Domain;

namespace PrimeWeb.Repo
{
    public class ContentRepository : Abstract.Repository<Content>
    {
        public ContentRepository(IUnitOfWork<DBContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
