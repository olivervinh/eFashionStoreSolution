using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Orders;
using eFashionStore.Model.Models.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Orders
{
    public interface IDiscountCodeService
    {
        DiscountCode Add(DiscountCode DiscountCode);

        void Update(DiscountCode DiscountCode);

        DiscountCode Delete(int id);

        IEnumerable<DiscountCode> GetAll();

        IEnumerable<DiscountCode> GetAll(string keyword);

        IEnumerable<DiscountCode> GetAllByParentId(int parentId);

        DiscountCode GetById(int id);

        Task<bool> SaveAsync();
    }
    public class DiscountCodeService : IDiscountCodeService
    {
        private IDiscountCodeRepository _discountCodeRepository;
        private IUnitOfWork _unitOfWork;
        public DiscountCodeService(IDiscountCodeRepository discountCodeRepository, IUnitOfWork unitOfWork)
        {
            this._discountCodeRepository = discountCodeRepository;
            this._unitOfWork = unitOfWork;
        }
        public DiscountCode Add(DiscountCode DiscountCode)
        {
            return _discountCodeRepository.Add(DiscountCode);
        }

        public DiscountCode Delete(int id)
        {
            return _discountCodeRepository.Delete(id);
        }

        public IEnumerable<DiscountCode> GetAll()
        {
            return _discountCodeRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<DiscountCode> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<DiscountCode> GetAllByParentId(int parentId)
        {
            return _discountCodeRepository.GetMulti(x =>x.Id == parentId);
        }

        public DiscountCode GetById(int id)
        {
            return _discountCodeRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(DiscountCode DiscountCode)
        {
            _discountCodeRepository.Update(DiscountCode);
        }
    }
}
