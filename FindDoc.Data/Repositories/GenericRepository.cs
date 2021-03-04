using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FindDoc.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FindDoc.Data.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _applicationDbContext;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _applicationDbContext.Set<T>().AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _applicationDbContext.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        { 
            return await _applicationDbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _applicationDbContext.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsyncById(string id)
        {

            var x = await _applicationDbContext.Set<T>().FindAsync(id);
            var y = x;
            return x;
        }

        public T Update(T entity)
        {
            _applicationDbContext.Set<T>().Update(entity);

            return entity;
        }
    }
}
