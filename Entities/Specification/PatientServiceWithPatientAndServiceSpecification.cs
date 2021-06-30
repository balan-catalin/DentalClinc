using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Entities.Specification
{
    public class PatientServiceWithPatientAndServiceSpecification : BaseSpecification<PatientService>
    {
        public PatientServiceWithPatientAndServiceSpecification()
        {
            AddInclude(x=>x.Patient);
            AddInclude(x=>x.Service);
        }

        public PatientServiceWithPatientAndServiceSpecification(int id)
            :base(x=>x.Id==id)
        {
            AddInclude(x => x.Patient);
            AddInclude(x => x.Service);
        }

        public PatientServiceWithPatientAndServiceSpecification(
            Expression<Func<PatientService, bool>> criteria,
            Func<IQueryable<PatientService>, IOrderedQueryable<PatientService>> orderBy = null)
            :base(criteria, orderBy)
        {
            AddInclude(x => x.Patient);
            AddInclude(x => x.Service);
        }
    }
}
