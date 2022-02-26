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
    public interface IOrderService : IBaseService<Order>
    {

    }
    public class OrderService : BaseService<Order>, IOrderService
    {
        private IOrderRepository _orderRepository;
        public OrderService(IBaseRepository<Order> repository, IOrderRepository orderRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _orderRepository = orderRepository;
        }

    }
}
