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
    public interface IProductLikeRepository : IBaseRepository<ProductLike>
    {
    }
    public class ProductLikeRepository : BaseRepository<ProductLike>, IProductLikeRepository
    {
        public ProductLikeRepository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}