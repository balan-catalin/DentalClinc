using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Entities.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List
            <Expression<Func<T, object>>>();

        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; }

        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            Criteria = criteria;
            OrderBy = orderBy;
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
