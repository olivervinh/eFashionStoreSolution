using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Orders;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Model.Models.Orders;
using eFashionStore.Service.Intrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eFashionStore.Service.Services.Orders
{
    public interface IDiscountCodeService : IBaseService<DiscountCode>
    {

    }
    public class DiscountCodeService : BaseService<DiscountCode>, IDiscountCodeService
    {
        private IDiscountCodeRepository _discountCodeRepository;
        public DiscountCodeService(IBaseRepository<DiscountCode> repository, IDiscountCodeRepository discountCodeRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _discountCodeRepository = discountCodeRepository;
        }

    }
}
