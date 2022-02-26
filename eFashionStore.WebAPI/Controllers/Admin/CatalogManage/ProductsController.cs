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
            var result = await _productService.CreateVariantProductBaseProduct(productDto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductDto productDto)
        {
            var result = await _productService.UpdateVariantProductBaseProduct(id,productDto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteImageBaseProduct(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
