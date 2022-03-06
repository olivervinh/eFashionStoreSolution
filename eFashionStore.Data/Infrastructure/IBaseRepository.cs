using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Infrastructure
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
       IQueryable<T> GetQueryable();
        Task<IEnumerable<T>> GetPaginationListAsync(IQueryable<T> queryableList,int pageNumber, int pageSize);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> CountAsync();
        Task<T> GetSingleAsyncById(int id);
        void AddRange(IEnumerable<T> entities);
        void DeleteRange(IEnumerable<T> entities);
        IQueryable<T> GetListCondition(Expression<Func<T, bool>> predicate);
    }
}
