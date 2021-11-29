using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.WareHouses;
using eFashionStore.Model.Models.WareHouses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.WareHouses
{
    public interface ISupplierService
    {
        Supplier Add(Supplier Supplier);

        void Update(Supplier Supplier);

        Supplier Delete(int id);

        IEnumerable<Supplier> GetAll();

        IEnumerable<Supplier> GetAll(string keyword);

        IEnumerable<Supplier> GetAllByParentId(int parentId);

        Supplier GetById(int id);

        Task<bool> SaveAsync();
    }
    public class SupplierService : ISupplierService
    {
        private ISupplierRepository _supplierRepository;
        private IUnitOfWork _unitOfWork;
        public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }
        public Supplier Add(Supplier Supplier)
        {
            return _supplierRepository.Add(Supplier);
        }

        public Supplier Delete(int id)
        {
            return _supplierRepository.Delete(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _supplierRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<Supplier> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<Supplier> GetAllByParentId(int parentId)
        {
            return _supplierRepository.GetMulti(x => x.Id == parentId);
        }

        public Supplier GetById(int id)
        {
            return _supplierRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(Supplier Supplier)
        {
            _supplierRepository.Update(Supplier);
        }
    }
}
