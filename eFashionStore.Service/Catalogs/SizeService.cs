using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Catalogs
{
    public interface ISizeService
    {
        Size Add(Size Size);

        void Update(Size Size);

        Size Delete(int id);

        IEnumerable<Size> GetAll();

        IEnumerable<Size> GetAll(string keyword);

        IEnumerable<Size> GetAllByParentId(int parentId);

        Size GetById(int id);

        Task<bool> SaveAsync();
    }
    public class SizeService : ISizeService
    {
        private ISizeRepository _sizeRepository;
        private IUnitOfWork _unitOfWork;
        public SizeService(ISizeRepository sizeRepository, IUnitOfWork unitOfWork)
        {
            this._sizeRepository = sizeRepository;
            this._unitOfWork = unitOfWork;
        }
        public Size Add(Size Size)
        {
            return _sizeRepository.Add(Size);
        }

        public Size Delete(int id)
        {
            return _sizeRepository.Delete(id);
        }

        public IEnumerable<Size> GetAll()
        {
            return _sizeRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<Size> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<Size> GetAllByParentId(int parentId)
        {
            return _sizeRepository.GetMulti(x =>x.Id == parentId);
        }

        public Size GetById(int id)
        {
            return _sizeRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(Size Size)
        {
            _sizeRepository.Update(Size);
        }
    }
}
