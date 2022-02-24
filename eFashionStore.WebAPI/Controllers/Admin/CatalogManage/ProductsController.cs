using eFahionStore.Common.RequestViewModels.Catalog;
using eFahionStore.Common.ResponseViewModels.Catalog;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Service.Services.Catalogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.WebAPI.Controllers.Admin.CatalogManage
{
    [Route("api/admin/catalog/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        private IImageProductService _imageProductService;
        public ProductsController(IProductService productService, IImageProductService imageProductService)
        {
            _productService = productService;
            _imageProductService = imageProductService;
        }
        [HttpGet("GetPaginationList")]
        public async Task<IEnumerable<ProductJoinImage>> GetProductsPaginationList(int pageNumber, int pageSize)
        {
            return await _productService.GetProductsPaginationListAsync(pageNumber, pageSize);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductDto productDto)
        {
            try
            {
                var product = new Product();
                await _productService.Add(product);
                int index = 0;
                foreach (var formFile in productDto.ImageProducts)
                {
                    if (formFile.Length > 0 && formFile.Length < 2048)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Pro", "product_" + product.Id);

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
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductDto productDto)
        {
            try
            {
                var imageProductBaseProductList = await _imageProductService.GetImageProductsBaseFkBlogId(id);
                foreach (var item in imageProductBaseProductList)
                {
                    System.IO.File.Delete(Path.Combine("wwwroot/Images/ImagesProduct", item.ImageName));
                }
                await _imageProductService.DeleteRange(imageProductBaseProductList);
                var product = new Product();
                await _productService.Update(product);
                int index = 0;
                foreach (var formFile in productDto.ImageProducts)
                {
                    if (formFile.Length > 0 && formFile.Length < 2048)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/ImagesProduct", "product_" + product.Id);

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
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var imageProductBaseProductList = await _imageProductService.GetImageProductsBaseFkBlogId(id);
                foreach (var item in imageProductBaseProductList)
                {
                    System.IO.File.Delete(Path.Combine("wwwroot/Images/ImagesProduct", item.ImageName));
                }
                var result = Task.Run(async () => await _imageProductService.DeleteRange(imageProductBaseProductList)).Result;
                var product = await _productService.GetSingleAsyncById(id);
                if (result)
                    await _productService.Delete(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
