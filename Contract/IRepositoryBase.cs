using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Specification;

namespace Contract
{
    public interface IRepositoryBase<T> where T :class
    {
        //Create
        void Add(T entity);

        void AddRange(IEnumerable<T> enitities);

        //Read
        T FindById(int id);

        T GetFirstOrDefault(ISpecification<T> spec);

        IEnumerable<T> GetAll(ISpecification<T> spec);

        //Update
        void Update(T enitity);

        void UpdateRange(IEnumerable<T> entities);

        //Delete
        void Remove(int id);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> enitities);

        //Async
        Task<T> FindByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();
        
        Task<IEnumerable<T>> GetAllAsync(ISpecification<T> spec);

        Task<T> GetFirstOrDefaultAsync(ISpecification<T> spec);

        //Other
        bool Any(Func<T, bool> source);
    }
}
