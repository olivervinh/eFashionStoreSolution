using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Model.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.Catalogs
{
    public interface IProductLikeRepository : IRepository<ProductLike>
    {
    }
    public class ProductLikeRepository : RepositoryBase<ProductLike>, IProductLikeRepository
    {
        public ProductLikeRepository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}