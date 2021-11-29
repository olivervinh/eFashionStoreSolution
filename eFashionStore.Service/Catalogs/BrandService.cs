using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Catalogs
{
    public interface IBrandService
    {
        Brand Add(Brand Brand);

        void Update(Brand Brand);

        Brand Delete(int id);

        IEnumerable<Brand> GetAll();

        IEnumerable<Brand> GetAll(string keyword);

        IEnumerable<Brand> GetAllByParentId(int parentId);

        Brand GetById(int id);

        Task<bool> SaveAsync();
    }
    public class BrandService : IBrandService
    {
        private IBrandRepository _brandRepository;
        private IUnitOfWork _unitOfWork;
        public BrandService(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            this._brandRepository = brandRepository;
            this._unitOfWork = unitOfWork;
        }
        public Brand Add(Brand Brand)
        {
            return _brandRepository.Add(Brand);
        }

        public Brand Delete(int id)
        {
            return _brandRepository.Delete(id);
        }

        public IEnumerable<Brand> GetAll()
        {
            return _brandRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<Brand> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<Brand> GetAllByParentId(int parentId)
        {
            return _brandRepository.GetMulti(x =>x.Id == parentId);
        }

        public Brand GetById(int id)
        {
            return _brandRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(Brand Brand)
        {
            _brandRepository.Update(Brand);
        }
    }
}
