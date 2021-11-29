using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Catalogs
{
    public interface IProductVariantService
    {
        ProductVariant Add(ProductVariant ProductVariant);

        void Update(ProductVariant ProductVariant);

        ProductVariant Delete(int id);

        IEnumerable<ProductVariant> GetAll();

        IEnumerable<ProductVariant> GetAll(string keyword);

        IEnumerable<ProductVariant> GetAllByParentId(int parentId);

        ProductVariant GetById(int id);

        Task<bool> SaveAsync();
    }
    public class ProductVariantService : IProductVariantService
    {
        private IProductVariantRepository _productVariantRepository;
        private IUnitOfWork _unitOfWork;
        public ProductVariantService(IProductVariantRepository productVariantRepository, IUnitOfWork unitOfWork)
        {
            this._productVariantRepository = productVariantRepository;
            this._unitOfWork = unitOfWork;
        }
        public ProductVariant Add(ProductVariant ProductVariant)
        {
            return _productVariantRepository.Add(ProductVariant);
        }

        public ProductVariant Delete(int id)
        {
            return _productVariantRepository.Delete(id);
        }

        public IEnumerable<ProductVariant> GetAll()
        {
            return _productVariantRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<ProductVariant> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<ProductVariant> GetAllByParentId(int parentId)
        {
            return _productVariantRepository.GetMulti(x =>x.Id == parentId);
        }

        public ProductVariant GetById(int id)
        {
            return _productVariantRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(ProductVariant ProductVariant)
        {
            _productVariantRepository.Update(ProductVariant);
        }
    }
}
