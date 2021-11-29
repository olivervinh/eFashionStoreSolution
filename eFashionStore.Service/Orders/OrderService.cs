using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Orders;
using eFashionStore.Model.Models.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Orders
{
    public interface IOrderService
    {
        Order Add(Order Order);

        void Update(Order Order);

        Order Delete(int id);

        IEnumerable<Order> GetAll();

        IEnumerable<Order> GetAll(string keyword);

        IEnumerable<Order> GetAllByParentId(int parentId);

        Order GetById(int id);

        Task<bool> SaveAsync();
    }
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._unitOfWork = unitOfWork;
        }
        public Order Add(Order Order)
        {
            return _orderRepository.Add(Order);
        }

        public Order Delete(int id)
        {
            return _orderRepository.Delete(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<Order> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<Order> GetAllByParentId(int parentId)
        {
            return _orderRepository.GetMulti(x =>x.Id == parentId);
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(Order Order)
        {
            _orderRepository.Update(Order);
        }
    }
}
