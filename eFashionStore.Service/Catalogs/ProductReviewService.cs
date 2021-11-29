using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Catalogs
{
    public interface IProductReviewService
    {
        ProductReview Add(ProductReview ProductReview);

        void Update(ProductReview ProductReview);

        ProductReview Delete(int id);

        IEnumerable<ProductReview> GetAll();

        IEnumerable<ProductReview> GetAll(string keyword);

        IEnumerable<ProductReview> GetAllByParentId(int parentId);

        ProductReview GetById(int id);

        Task<bool> SaveAsync();
    }
    public class ProductReviewService : IProductReviewService
    {
        private IProductReviewRepository _productReviewRepository;
        private IUnitOfWork _unitOfWork;
        public ProductReviewService(IProductReviewRepository productReviewRepository, IUnitOfWork unitOfWork)
        {
            this._productReviewRepository = productReviewRepository;
            this._unitOfWork = unitOfWork;
        }
        public ProductReview Add(ProductReview ProductReview)
        {
            return _productReviewRepository.Add(ProductReview);
        }

        public ProductReview Delete(int id)
        {
            return _productReviewRepository.Delete(id);
        }

        public IEnumerable<ProductReview> GetAll()
        {
            return _productReviewRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<ProductReview> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<ProductReview> GetAllByParentId(int parentId)
        {
            return _productReviewRepository.GetMulti(x =>x.Id == parentId);
        }

        public ProductReview GetById(int id)
        {
            return _productReviewRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(ProductReview ProductReview)
        {
            _productReviewRepository.Update(ProductReview);
        }
    }
}
