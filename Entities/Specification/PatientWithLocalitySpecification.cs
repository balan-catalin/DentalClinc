using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Entities.Specification
{
    public class PatientWithLocalitySpecification : BaseSpecification<Patient>
    {
        public PatientWithLocalitySpecification()
        {
            AddInclude(x=>x.Locality);
        }

        public PatientWithLocalitySpecification(int id)
            :base(x => x.Id == id)
        {
            AddInclude(x => x.Locality);
        }

        public PatientWithLocalitySpecification(
            Expression<Func<Patient, bool>> criteria,
            Func<IQueryable<Patient>, IOrderedQueryable<Patient>> orderBy = null)
            :base(criteria, orderBy)
        {
            AddInclude(x => x.Locality);
        }
    }
}
