using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Catalogs
{
    public interface IBlogService
    {
        Blog Add(Blog Blog);

        void Update(Blog Blog);

        Blog Delete(int id);

        IEnumerable<Blog> GetAll();

        IEnumerable<Blog> GetAll(string keyword);

        IEnumerable<Blog> GetAllByParentId(int parentId);

        Blog GetById(int id);

        Task<bool> SaveAsync();
    }
    public class BlogService : IBlogService
    {
        private IBlogRepository _blogRepository;
        private IUnitOfWork _unitOfWork;
        public BlogService(IBlogRepository blogRepository, IUnitOfWork unitOfWork)
        {
            this._blogRepository = blogRepository;
            this._unitOfWork = unitOfWork;
        }
        public Blog Add(Blog Blog)
        {
            return _blogRepository.Add(Blog);
        }

        public Blog Delete(int id)
        {
            return _blogRepository.Delete(id);
        }

        public IEnumerable<Blog> GetAll()
        {
            return _blogRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<Blog> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<Blog> GetAllByParentId(int parentId)
        {
            return _blogRepository.GetMulti(x =>x.Id == parentId);
        }

        public Blog GetById(int id)
        {
            return _blogRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(Blog Blog)
        {
            _blogRepository.Update(Blog);
        }
    }
}
