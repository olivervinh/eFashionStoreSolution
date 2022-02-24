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
        public Task<IEnumerable<ImageProduct>> GetImageProductsBaseFkBlogId(int FkProductId);
    }
    public class ImageProductService : BaseService<ImageProduct>, IImageProductService
    {
        private IImageProductRepository _imageProductRepository;
        public ImageProductService(IBaseRepository<ImageProduct> repository, IImageProductRepository imageProductRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _imageProductRepository = imageProductRepository;
        }

        public async Task<IEnumerable<ImageProduct>> GetImageProductsBaseFkBlogId(int FkProductId)
        {
            return await _imageProductRepository.GetImageProductsBaseFkBlogId(FkProductId);
        }
    }
}
