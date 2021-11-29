using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Catalogs
{
    public interface IImageProductService
    {
        ImageProduct Add(ImageProduct ImageProduct);

        void Update(ImageProduct ImageProduct);

        ImageProduct Delete(int id);

        IEnumerable<ImageProduct> GetAll();

        IEnumerable<ImageProduct> GetAll(string keyword);

        IEnumerable<ImageProduct> GetAllByParentId(int parentId);

        ImageProduct GetById(int id);

        Task<bool> SaveAsync();
    }
    public class ImageProductService : IImageProductService
    {
        private IImageProductRepository _imageProductRepository;
        private IUnitOfWork _unitOfWork;
        public ImageProductService(IImageProductRepository imageProductRepository, IUnitOfWork unitOfWork)
        {
            this._imageProductRepository = imageProductRepository;
            this._unitOfWork = unitOfWork;
        }
        public ImageProduct Add(ImageProduct ImageProduct)
        {
            return _imageProductRepository.Add(ImageProduct);
        }

        public ImageProduct Delete(int id)
        {
            return _imageProductRepository.Delete(id);
        }

        public IEnumerable<ImageProduct> GetAll()
        {
            return _imageProductRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<ImageProduct> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<ImageProduct> GetAllByParentId(int parentId)
        {
            return _imageProductRepository.GetMulti(x =>x.Id == parentId);
        }

        public ImageProduct GetById(int id)
        {
            return _imageProductRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(ImageProduct ImageProduct)
        {
            _imageProductRepository.Update(ImageProduct);
        }
    }
}
