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
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> CountAsync();
        Task<T> GetSingleAsyncById(int id);
        void AddRange(IEnumerable<T> entities);
        void DeleteRange(IEnumerable<T> entities);
    }
}
