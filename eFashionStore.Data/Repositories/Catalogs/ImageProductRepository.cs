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
    public interface IImageProductRepository : IRepository<ImageProduct>
    {
    }
    public class ImageProductRepository : RepositoryBase<ImageProduct>, IImageProductRepository
    {
        public ImageProductRepository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}