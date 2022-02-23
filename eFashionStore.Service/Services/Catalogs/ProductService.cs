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
    public interface IProductService : IBaseService<Product>
    {

    }
    public class ProductService : BaseService<Product>, IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IBaseRepository<Product> repository, IProductRepository productRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
        }

    }
}
