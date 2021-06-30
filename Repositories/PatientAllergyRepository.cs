using System;
using System.Collections.Generic;
using System.Text;
using Contract;
using Entities;

namespace Repositories
{
    class PatientAllergyRepository : RepositoryBase<PatientAllergy>, IPatientAllergyRepository
    {
        private readonly DbContext _context;

        public PatientAllergyRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
