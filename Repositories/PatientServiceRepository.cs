using System;
using System.Collections.Generic;
using System.Text;
using Contract;
using Entities;

namespace Repositories
{
    class PatientServiceRepository : RepositoryBase<PatientService>, IPatientServiceRepository
    {
        private readonly DbContext _context;

        public PatientServiceRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
