using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.WareHouses;
using eFashionStore.Model.Models.WareHouses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.WareHouses
{
    public interface IWareHouseBillDetailService
    {
        WareHouseBillDetail Add(WareHouseBillDetail WareHouseBillDetail);

        void Update(WareHouseBillDetail WareHouseBillDetail);

        WareHouseBillDetail Delete(int id);

        IEnumerable<WareHouseBillDetail> GetAll();

        IEnumerable<WareHouseBillDetail> GetAll(string keyword);

        IEnumerable<WareHouseBillDetail> GetAllByParentId(int parentId);

        WareHouseBillDetail GetById(int id);

        Task<bool> SaveAsync();
    }
    public class WareHouseBillDetailService : IWareHouseBillDetailService
    {
        private IWareHouseBillDetailRepository _WareHouseBillDetailRepository;
        private IUnitOfWork _unitOfWork;
        public WareHouseBillDetailService(IWareHouseBillDetailRepository WareHouseBillDetailRepository, IUnitOfWork unitOfWork)
        {
            this._WareHouseBillDetailRepository = WareHouseBillDetailRepository;
            this._unitOfWork = unitOfWork;
        }
        public WareHouseBillDetail Add(WareHouseBillDetail WareHouseBillDetail)
        {
            return _WareHouseBillDetailRepository.Add(WareHouseBillDetail);
        }

        public WareHouseBillDetail Delete(int id)
        {
            return _WareHouseBillDetailRepository.Delete(id);
        }

        public IEnumerable<WareHouseBillDetail> GetAll()
        {
            return _WareHouseBillDetailRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<WareHouseBillDetail> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<WareHouseBillDetail> GetAllByParentId(int parentId)
        {
            return _WareHouseBillDetailRepository.GetMulti(x =>x.Id == parentId);
        }

        public WareHouseBillDetail GetById(int id)
        {
            return _WareHouseBillDetailRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(WareHouseBillDetail WareHouseBillDetail)
        {
            _WareHouseBillDetailRepository.Update(WareHouseBillDetail);
        }
    }
}
