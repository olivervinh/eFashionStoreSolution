using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Catalogs
{
    public interface IImageBlogService
    {
        ImageBlog Add(ImageBlog ImageBlog);

        void Update(ImageBlog ImageBlog);

        ImageBlog Delete(int id);

        IEnumerable<ImageBlog> GetAll();

        IEnumerable<ImageBlog> GetAll(string keyword);

        IEnumerable<ImageBlog> GetAllByParentId(int parentId);

        ImageBlog GetById(int id);

        Task<bool> SaveAsync();
    }
    public class ImageBlogService : IImageBlogService
    {
        private IImageBlogRepository _imageBlogRepository;
        private IUnitOfWork _unitOfWork;
        public ImageBlogService(IImageBlogRepository imageBlogRepository, IUnitOfWork unitOfWork)
        {
            this._imageBlogRepository = imageBlogRepository;
            this._unitOfWork = unitOfWork;
        }
        public ImageBlog Add(ImageBlog ImageBlog)
        {
            return _imageBlogRepository.Add(ImageBlog);
        }

        public ImageBlog Delete(int id)
        {
            return _imageBlogRepository.Delete(id);
        }

        public IEnumerable<ImageBlog> GetAll()
        {
            return _imageBlogRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<ImageBlog> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<ImageBlog> GetAllByParentId(int parentId)
        {
            return _imageBlogRepository.GetMulti(x =>x.Id == parentId);
        }

        public ImageBlog GetById(int id)
        {
            return _imageBlogRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(ImageBlog ImageBlog)
        {
            _imageBlogRepository.Update(ImageBlog);
        }
    }
}
