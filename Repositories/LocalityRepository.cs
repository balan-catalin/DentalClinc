using Contract;
using Entities;

namespace Repositories
{
    public class LocalityRepository :RepositoryBase<Locality>, ILocalityRepository
    {
        private readonly DbContext _context;

        public LocalityRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}