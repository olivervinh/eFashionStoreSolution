using eFahionStore.Common.Helpers;
using eFashionStore.Data.EF;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Infrastructure
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Properties
        private readonly EFashionStoreDbContext _context;
        public BaseRepository(EFashionStoreDbContext context)
        {
            this._context = context;
        }
        #endregion
        #region Implementation

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public virtual void Add(T entity)
        {
             _context.Set<T>().Add(entity);
        }
        public virtual async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public virtual void Delete(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public virtual async Task<T> GetSingleAsyncById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public virtual void Update(T entity)
        {
           
            _context.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }

        public async Task<IEnumerable<T>> GetPaginationListAsync(int pageNumber, int pageSize)
        {
            var list = _context.Set<T>().AsQueryable();
            var paginationList = PagedPaginationHelper<T>.ToPagedListAsync(list, pageNumber, pageSize);
            return await paginationList;
        }
        #endregion
    }
}
