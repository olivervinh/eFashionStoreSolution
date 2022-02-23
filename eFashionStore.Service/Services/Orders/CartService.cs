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
    public interface ICartService : IBaseService<Cart>
    {

    }
    public class CartService : BaseService<Cart>, ICartService
    {
        private ICartRepository _cartRepository;
        public CartService(IBaseRepository<Cart> repository, ICartRepository cartRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _cartRepository = cartRepository;
        }

    }
}
