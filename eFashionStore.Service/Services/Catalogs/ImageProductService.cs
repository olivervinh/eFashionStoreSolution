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
    public interface IImageProductService : IBaseService<ImageProduct>
    {

    }
    public class ImageProductService : BaseService<ImageProduct>, IImageProductService
    {
        private IImageProductRepository _imageProductRepository;
        public ImageProductService(IBaseRepository<ImageProduct> repository, IImageProductRepository imageProductRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _imageProductRepository = imageProductRepository;
        }

    }
}
