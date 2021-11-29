using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.WareHouses;
using eFashionStore.Model.Models.WareHouses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.WareHouses
{
    public interface IWareHouseBillService
    {
        WareHouseBill Add(WareHouseBill WareHouseBill);

        void Update(WareHouseBill WareHouseBill);

        WareHouseBill Delete(int id);

        IEnumerable<WareHouseBill> GetAll();

        IEnumerable<WareHouseBill> GetAll(string keyword);

        IEnumerable<WareHouseBill> GetAllByParentId(int parentId);

        WareHouseBill GetById(int id);

        Task<bool> SaveAsync();
    }
    public class WareHouseBillService : IWareHouseBillService
    {
        private IWareHouseBillRepository _wareHouseBillRepository;
        private IUnitOfWork _unitOfWork;
        public WareHouseBillService(IWareHouseBillRepository wareHouseBillRepository, IUnitOfWork unitOfWork)
        {
            this._wareHouseBillRepository = wareHouseBillRepository;
            this._unitOfWork = unitOfWork;
        }
        public WareHouseBill Add(WareHouseBill WareHouseBill)
        {
            return _wareHouseBillRepository.Add(WareHouseBill);
        }

        public WareHouseBill Delete(int id)
        {
            return _wareHouseBillRepository.Delete(id);
        }

        public IEnumerable<WareHouseBill> GetAll()
        {
            return _wareHouseBillRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<WareHouseBill> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<WareHouseBill> GetAllByParentId(int parentId)
        {
            return _wareHouseBillRepository.GetMulti(x =>x.Id == parentId);
        }

        public WareHouseBill GetById(int id)
        {
            return _wareHouseBillRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(WareHouseBill WareHouseBill)
        {
            _wareHouseBillRepository.Update(WareHouseBill);
        }
    }
}
