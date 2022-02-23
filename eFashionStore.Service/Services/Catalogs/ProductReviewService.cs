using eFahionStore.Common.ViewModal.Catalog;
using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Service.Intrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eFashionStore.Service.Services.Catalogs
{
    public interface IProductReviewService : IBaseService<ProductReview>
    {

    }
    public class ProductReviewService : BaseService<ProductReview>, IProductReviewService
    {
        private IProductReviewRepository _productReviewRepository;
        public ProductReviewService(IBaseRepository<ProductReview> repository, IProductReviewRepository productReviewRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _productReviewRepository = productReviewRepository;
        }

    }
}
