using eFahionStore.Common.RequestViewModels.Catalog;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Service.Services.Catalogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.WebAPI.Controllers.Admin.CatalogManage
{
    [Route("api/admin/catalog/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("GetPaginationList")]
        public async Task<IEnumerable<Brand>> GetBrandsPaginationList(int pageNumber = 2, int pageSize=3)
        {
            return await _brandService.GetPaginationListAsync(pageNumber, pageSize);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromForm] BrandDto brandDto)
        {
            try
            {
                var brand = new Brand(0,brandDto.Name);
                await _brandService.Add(brand);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, [FromForm] BrandDto brandDto)
        {
            try
            {
                var brand = new Brand(id,brandDto.Name);
                await _brandService.Update(brand);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
         
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                var brand = await _brandService.GetSingleAsyncById(id);
                await _brandService.Delete(brand);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
