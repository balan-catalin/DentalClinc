using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Entities.Specification
{
    public class PatientAllergyWithPatientAndAllergySpecification : BaseSpecification<PatientAllergy>
    {
        public PatientAllergyWithPatientAndAllergySpecification()
        {
            AddInclude(x=>x.Allergy);
            AddInclude(x=>x.Patient);
        }

        public PatientAllergyWithPatientAndAllergySpecification(int id)
            :base(x => x.Id == id)
        {
            AddInclude(x => x.Allergy);
            AddInclude(x => x.Patient);
        }

        public PatientAllergyWithPatientAndAllergySpecification(
            Expression<Func<PatientAllergy, bool>> criteria,
            Func<IQueryable<PatientAllergy>, IOrderedQueryable<PatientAllergy>> orderBy = null)
            : base(criteria, orderBy)
        {
            AddInclude(x => x.Allergy);
            AddInclude(x => x.Patient);
        }
    }
}
