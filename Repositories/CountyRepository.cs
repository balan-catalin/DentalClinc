using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Entities;

namespace Repositories
{
    public class CountyRepository : RepositoryBase<County> ,ICountyRepository
    {
        private readonly DbContext _context;

        public CountyRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
