using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Entities.Specification
{
    public class LocalityWithCountySpecification : BaseSpecification<Locality>
    {
        public LocalityWithCountySpecification()
        {
            AddInclude(x => x.County);
        }

        public LocalityWithCountySpecification(int id)
            :base(x => x.Id == id)
        {
            AddInclude(x => x.County);
        }

        public LocalityWithCountySpecification(
            Expression<Func<Locality, bool>> criteria, 
            Func<IQueryable<Locality>, IOrderedQueryable<Locality>> orderBy = null)
            :base(criteria, orderBy)
        {
            AddInclude(x => x.County);
        }
    }
}
