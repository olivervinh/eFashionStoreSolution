using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Orders;
using eFashionStore.Model.Models.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Orders
{
    public interface ICartService
    {
        Cart Add(Cart Cart);

        void Update(Cart Cart);

        Cart Delete(int id);

        IEnumerable<Cart> GetAll();

        IEnumerable<Cart> GetAll(string keyword);

        IEnumerable<Cart> GetAllByParentId(int parentId);

        Cart GetById(int id);

        Task<bool> SaveAsync();
    }
    public class CartService : ICartService
    {
        private ICartRepository _cartRepository;
        private IUnitOfWork _unitOfWork;
        public CartService(ICartRepository cartRepository, IUnitOfWork unitOfWork)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
        }
        public Cart Add(Cart Cart)
        {
            return _cartRepository.Add(Cart);
        }

        public Cart Delete(int id)
        {
            return _cartRepository.Delete(id);
        }

        public IEnumerable<Cart> GetAll()
        {
            return _cartRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<Cart> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<Cart> GetAllByParentId(int parentId)
        {
            return _cartRepository.GetMulti(x => x.Id == parentId);
        }

        public Cart GetById(int id)
        {
            return _cartRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(Cart Cart)
        {
            _cartRepository.Update(Cart);
        }
    }
}
