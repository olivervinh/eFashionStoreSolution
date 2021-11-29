using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Catalogs
{
    public interface IProductLikeService
    {
        ProductLike Add(ProductLike ProductLike);

        void Update(ProductLike ProductLike);

        ProductLike Delete(int id);

        IEnumerable<ProductLike> GetAll();

        IEnumerable<ProductLike> GetAll(string keyword);

        IEnumerable<ProductLike> GetAllByParentId(int parentId);

        ProductLike GetById(int id);

        Task<bool> SaveAsync();
    }
    public class ProductLikeService : IProductLikeService
    {
        private IProductLikeRepository _productLikeRepository;
        private IUnitOfWork _unitOfWork;
        public ProductLikeService(IProductLikeRepository productLikeRepository, IUnitOfWork unitOfWork)
        {
            this._productLikeRepository = productLikeRepository;
            this._unitOfWork = unitOfWork;
        }
        public ProductLike Add(ProductLike ProductLike)
        {
            return _productLikeRepository.Add(ProductLike);
        }

        public ProductLike Delete(int id)
        {
            return _productLikeRepository.Delete(id);
        }

        public IEnumerable<ProductLike> GetAll()
        {
            return _productLikeRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<ProductLike> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<ProductLike> GetAllByParentId(int parentId)
        {
            return _productLikeRepository.GetMulti(x =>x.Id == parentId);
        }

        public ProductLike GetById(int id)
        {
            return _productLikeRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(ProductLike ProductLike)
        {
            _productLikeRepository.Update(ProductLike);
        }
    }
}
