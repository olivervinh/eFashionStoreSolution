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


namespace eFashionStore.Service.Services.Catalogs
{
    public interface IOrderDetailService : IBaseService<OrderDetail>
    {

    }
    public class OrderDetailService : BaseService<OrderDetail>, IOrderDetailService
    {
        private IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IBaseRepository<OrderDetail> repository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _orderDetailRepository = orderDetailRepository;
        }

    }
}
