using Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities;
using Entities.Specification;
using Repositories.Specification;

namespace Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly DbContext _context;
        internal DbSet<T> dbSet;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        //Create
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> enitities)
        {
            dbSet.AddRange(enitities);
        }

        //Read
        public T FindById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(ISpecification<T> spec)
        {
            return ApplySpecification(spec).ToList();
        }

        public T GetFirstOrDefault(ISpecification<T> spec)
        {
            return ApplySpecification(spec).FirstOrDefault();
        }

        //Update
        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            dbSet.UpdateRange(entities);
        }

        //Delete
        public void Remove(int id)
        {
            T entity = dbSet.Find(id);
            Remove(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> enitities)
        {
            dbSet.RemoveRange(enitities);
        }

        //Async
        public async Task<T> FindByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetFirstOrDefaultAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        //Other
        public bool Any(Func<T,bool> source)
        {
            return dbSet.Any(source);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
