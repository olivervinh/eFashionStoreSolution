using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Orders;
using eFashionStore.Model.Models.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Orders
{
    public interface IOrderDetailService
    {
        OrderDetail Add(OrderDetail OrderDetail);

        void Update(OrderDetail OrderDetail);

        OrderDetail Delete(int id);

        IEnumerable<OrderDetail> GetAll();

        IEnumerable<OrderDetail> GetAll(string keyword);

        IEnumerable<OrderDetail> GetAllByParentId(int parentId);

        OrderDetail GetById(int id);

        Task<bool> SaveAsync();
    }
    public class OrderDetailService : IOrderDetailService
    {
        private IOrderDetailRepository _orderDetailRepository;
        private IUnitOfWork _unitOfWork;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._orderDetailRepository = orderDetailRepository;
            this._unitOfWork = unitOfWork;
        }
        public OrderDetail Add(OrderDetail OrderDetail)
        {
            return _orderDetailRepository.Add(OrderDetail);
        }

        public OrderDetail Delete(int id)
        {
            return _orderDetailRepository.Delete(id);
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _orderDetailRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<OrderDetail> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<OrderDetail> GetAllByParentId(int parentId)
        {
            return _orderDetailRepository.GetMulti(x =>x.Id == parentId);
        }

        public OrderDetail GetById(int id)
        {
            return _orderDetailRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(OrderDetail OrderDetail)
        {
            _orderDetailRepository.Update(OrderDetail);
        }
    }
}
