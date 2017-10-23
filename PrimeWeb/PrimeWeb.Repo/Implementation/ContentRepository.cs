using PrimeWeb.Core.Data;
using PrimeWeb.Data;
using PrimeWeb.Data.Domain;

namespace PrimeWeb.Repo.Implementation
{
    public class ContentRepository : Abstract.Repository<Content>, IContentRepository
    {
        public ContentRepository(IUnitOfWork<DBContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
