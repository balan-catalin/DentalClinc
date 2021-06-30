using System;
using System.Collections.Generic;
using System.Text;
using Contract;
using Entities;

namespace Repositories
{
    class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        private readonly DbContext _context;

        public ServiceRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
