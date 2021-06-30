using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using Entities.Specification;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Specification
{
    public class SpecificationEvaluator<TEntity> where TEntity : Entity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null)
            {
                query = spec.OrderBy(query);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
