using eFashionStore.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Service.Intrastructure
{
    public class BaseService<T> : IBaseService<T> where T : class

    {
        private IBaseRepository<T> _repository;
        private IUnitOfWork _unitOfWork;
        public BaseService(IBaseRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(T entity)
        {
            try
            {
                _repository.Add(entity);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
           
          
        }

        public async Task<int> CountAsync()
        {
            return await _repository.CountAsync();
        }

        public async Task<bool> Delete(T entity)
        {
            try
            {
                _repository.Delete(entity);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteRange(IEnumerable<T> entities)
        {
            try
            {
                _repository.DeleteRange(entities);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<IEnumerable<T>> GetPaginationListAsync(IQueryable<T> queryableList, int pageNumber, int pageSize)
        {         
            return _repository.GetPaginationListAsync(queryableList, pageNumber, pageSize);
        }

        public IQueryable<T> GetQueryable()
        {
            return _repository.GetQueryable();
        }

        public async Task<T> GetSingleAsyncById(int id)
        {
            return await _repository.GetSingleAsyncById(id);
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                _repository.Update(entity);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
