using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.WareHouses;
using eFashionStore.Model.Models.WareHouses;
using eFashionStore.Service.Intrastructure;


namespace eFashionStore.Service.Services.WareHouses
{
    public interface IWareHouseBillDetailService : IBaseService<WareHouseBillDetail>
    {

    }
    public class WareHouseBillDetailService : BaseService<WareHouseBillDetail>, IWareHouseBillDetailService
    {
        private IWareHouseBillDetailRepository _wareHouseBillDetailRepository;
        public WareHouseBillDetailService(IBaseRepository<WareHouseBillDetail> repository, IWareHouseBillDetailRepository wareHouseBillDetailRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _wareHouseBillDetailRepository = wareHouseBillDetailRepository;
        }

    }
}
