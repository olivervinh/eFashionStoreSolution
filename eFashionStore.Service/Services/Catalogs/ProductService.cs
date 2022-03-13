using eFahionStore.Common.RequestViewModels.Catalog;
using eFahionStore.Common.ResponseViewModels.Catalog;
using eFahionStore.Common.ViewModal.Catalog;
using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Service.Intrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eFashionStore.Service.Services.Catalogs
{
    public interface IProductService : IBaseService<Product>
    {
        public Task<IEnumerable<Product>> GetProductsSearchSortOrderPagination(string searchString,int? pageNumber, string sortOrder);
        public Task<bool> CreateVariantProductBaseProduct(ProductDto productDto);
        public Task<bool> UpdateVariantProductBaseProduct(int id,ProductDto productDto);
        public Task<bool> DeleteImageBaseProduct(int id);
        public IQueryable<Product> GetProductsListCondition(string Search);
    }
    public class ProductService : BaseService<Product>, IProductService
    {
        private IProductRepository _productRepository;
        private IImageProductService _imageProductService;
        private IProductVariantService _productVariantService;
        public ProductService(IProductVariantService productVariantService, IBaseRepository<Product> repository, IImageProductService imageProductService, IProductRepository productRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _imageProductService = imageProductService;
            _productVariantService = productVariantService;
        }
        public async Task<IEnumerable<Product>> GetProductsSearchSortOrderPagination(string searchString, int? pageNumber, string sortOrder)
        {
            var condition = this.GetQueryable();
            if (searchString != null)
                condition = this.GetProductsListCondition(searchString);
            switch (sortOrder)
            {
                case "id_desc":
                    condition = condition.OrderByDescending(s => s.Id);
                    break;
                case "name":
                    condition = condition.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    condition = condition.OrderByDescending(s => s.Name);
                    break;
                default:
                    condition = condition.OrderBy(s => s.Id);
                    break;
            }

            return await _productRepository.GetCustomProductsPaginationListAsync(condition, pageNumber ?? 1, 5);
        }

        public async Task<bool> CreateVariantProductBaseProduct(ProductDto productDto)
        {
            try
            {
                var product = new Product();
                await this.Add(product);
                int index = 0;
                foreach (var formFile in productDto.ImageProducts)
                {
                    if (formFile.Length > 0 && formFile.Length < 2048)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/list-image-products", "product_" + product.Id);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        if (index == 0)
                        {
                            var imageProduct = new ImageProduct();
                            await _imageProductService.Add(imageProduct);
                        }
                        else
                        {
                            var imageProduct = new ImageProduct();
                            await _imageProductService.Add(imageProduct);
                        }

                    }
                    index++;
                }
                foreach (var item in productDto.ProductVariantDtos)
                {
                    var productVariant = new ProductVariant(0,0,product.Id,null,item.FkColorId,null,item.FkSizeId,null,null);
                    await _productVariantService.Add(productVariant);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public async Task<bool> UpdateVariantProductBaseProduct(int id,ProductDto productDto)
        {
            try
            {
                var imageProductBaseProductList = await _imageProductService.GetImageProductsBaseFkBlogId(id);
                foreach (var item in imageProductBaseProductList)
                {
                    System.IO.File.Delete(Path.Combine("wwwroot/Images/list-image-products", item.ImageName));
                }
                await _imageProductService.DeleteRange(imageProductBaseProductList);
                var product = new Product();
                await this.Update(product);
                int index = 0;
                foreach (var formFile in productDto.ImageProducts)
                {
                    if (formFile.Length > 0 && formFile.Length < 2048)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/list-image-products", "product_" + product.Id);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        if (index == 0)
                        {
                            var imageProduct = new ImageProduct(0, "product_" + product.Id, true, product.Id, null);
                            await _imageProductService.Add(imageProduct);
                        }
                        else
                        {
                            var imageProduct = new ImageProduct(0, "product_" + product.Id, false, product.Id, null);
                            await _imageProductService.Add(imageProduct);
                        }

                    }
                    index++;
                }
                foreach (var item in productDto.ProductVariantDtos)
                {
                    var productVariant = new ProductVariant(item.Id, 0, product.Id, null, item.FkColorId, null, item.FkSizeId, null, null);
                    await _productVariantService.Update(productVariant);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteImageBaseProduct(int id)
        {
            try
            {
                var imageProductBaseProductList = await _imageProductService.GetImageProductsBaseFkBlogId(id);
                foreach (var item in imageProductBaseProductList)
                {
                    System.IO.File.Delete(Path.Combine("wwwroot/Images/ImagesProduct", item.ImageName));
                }
                var result = Task.Run(async () => await _imageProductService.DeleteRange(imageProductBaseProductList)).Result;
                var product = await this.GetSingleAsyncById(id);
                if (result)
                    await this.Delete(product);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<Product> GetProductsListCondition(string Search)
        {
            if (int.TryParse(Search, out int id))
                return _productRepository.GetListCondition(x => x.Name.Contains(Search) || x.Id == id);
            return _productRepository.GetListCondition(x => x.Name.Contains(Search));
        }
    }
}
