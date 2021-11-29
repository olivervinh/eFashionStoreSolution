using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Model.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.Orders
{
    public interface ICartRepository : IRepository<Cart>
    {
    }
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    { 
        public CartRepository(EFashionStoreDbContext context) : base(context)
        {
           
        }
    }
}
