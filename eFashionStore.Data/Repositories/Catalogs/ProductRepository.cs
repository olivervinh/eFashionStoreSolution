using eFahionStore.Common.Helpers;
using eFahionStore.Common.ResponseViewModels.Catalog;
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
    public interface IProductRepository : IBaseRepository<Product>
    {
        public Task<IEnumerable<ProductJoinImageCategoryBrand>> GetCustomProductsPaginationListAsync(int pageNumber, int pageSize);
    }
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly EFashionStoreDbContext _context;
        public ProductRepository(EFashionStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductJoinImageCategoryBrand>> GetCustomProductsPaginationListAsync(int pageNumber, int pageSize)
        {
            var productsList = (from p in _context.Products
                                join ip in _context.ImageProducts.Where(x => x.IsThumbnail == true)
                                on p.Id equals ip.FkProductId
                                join b in _context.Brands
                                on p.FkBrandId equals b.Id
                                join c in _context.Categories
                                on p.FkCategoryId equals c.Id
                                join s in _context.Suppliers
                                on p.FkSupplierId equals s.Id
                                select new ProductJoinImageCategoryBrand()
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Description = p.Description,
                                    SellPrice = p.SellPrice,
                                    ImportPrice = p.ImportPrice,
                                    PromotionPrice = p.PromotionPrice,
                                    Tag = p.Tag,
                                    Guide = p.Guide,
                                    Ingredient = p.Ingredient,
                                    StatusProduct = p.StatusProduct,
                                    IsActive = p.IsActive,
                                    Gender = p.Gender,
                                    BrandName = b.Name,
                                    CategoryName = c.Name,
                                    SupplierName = s.Name,
                                    Image = ip.ImageName,
                                });
            var productsPaginationList = PagedPaginationHelper<ProductJoinImageCategoryBrand>.ToPagedListAsync(productsList, pageNumber, pageSize);
            return await productsPaginationList;
        }
    }
}