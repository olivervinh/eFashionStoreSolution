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
    public interface IProductReviewRepository : IRepository<ProductReview>
    {
    }
    public class ProductReviewRepository : RepositoryBase<ProductReview>, IProductReviewRepository
    {
        public ProductReviewRepository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}