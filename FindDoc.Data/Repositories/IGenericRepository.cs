using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FindDoc.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsyncById(string id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Delete(T entity);
        T Update(T entity);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
    }
}
