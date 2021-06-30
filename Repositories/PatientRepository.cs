using Contract;
using Entities;
using Entities.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        private readonly DbContext _dbContext;

        public PatientRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Patient dbPatient, Patient patient)
        {
            dbPatient.MapDbPatientPatient(patient);
        }
    }
}
