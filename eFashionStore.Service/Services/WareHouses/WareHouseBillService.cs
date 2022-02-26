using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Orders;
using eFashionStore.Data.Repositories.WareHouses;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Model.Models.Orders;
using eFashionStore.Model.Models.WareHouses;
using eFashionStore.Service.Intrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eFashionStore.Service.Services.WareHouses
{
    public interface IWareHouseBillService : IBaseService<WareHouseBill>
    {

    }
    public class WareHouseBillService : BaseService<WareHouseBill>, IWareHouseBillService
    {
        private IWareHouseBillRepository _wareHouseBillRepository;
        public WareHouseBillService(IBaseRepository<WareHouseBill> repository, IWareHouseBillRepository wareHouseBillRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _wareHouseBillRepository = wareHouseBillRepository;
        }

    }
}
