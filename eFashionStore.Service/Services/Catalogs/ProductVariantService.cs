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
    public interface IProductVariantService : IBaseService<ProductVariant>
    {

    }
    public class ProductVariantService : BaseService<ProductVariant>, IProductVariantService
    {
        private IProductVariantRepository _productVariantRepository;
        public ProductVariantService(IBaseRepository<ProductVariant> repository, IProductVariantRepository productVariantRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _productVariantRepository = productVariantRepository;
        }

    }
}
