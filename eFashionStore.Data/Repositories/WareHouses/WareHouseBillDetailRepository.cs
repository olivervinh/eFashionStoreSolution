using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Model.Models.WareHouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.WareHouses
{
    public interface IWareHouseBillDetailRepository : IBaseRepository<WareHouseBillDetail>
    {
    }
    public class WareHouseBillDetailRepository : BaseRepository<WareHouseBillDetail>, IWareHouseBillDetailRepository
    {
        public WareHouseBillDetailRepository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}