using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Service.Intrastructure
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetQueryable();
        Task<IEnumerable<T>> GetPaginationListAsync(IQueryable<T> queryableList ,int pageNumber, int pageSize);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<int> CountAsync();
        Task<T> GetSingleAsyncById(int id);
        Task<bool> DeleteRange(IEnumerable<T> entities);
        
    }
}
