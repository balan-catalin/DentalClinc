using System;
using System.Collections.Generic;
using System.Text;
using Contract;
using Entities;

namespace Repositories
{
    public class AllergyRepository : RepositoryBase<Allergy>, IAllergyRepository
    {
        private readonly DbContext _context;

        public AllergyRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
