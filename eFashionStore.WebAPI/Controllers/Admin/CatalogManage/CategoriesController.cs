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
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("GetPaginationList")]
        public async Task<IEnumerable<Category>> GetBrandsPaginationList(int pageNumber, int pageSize)
        {
            return await _categoryService.GetPaginationListAsync(pageNumber, pageSize);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromForm] CategoryDto categoryDto)
        {
            try
            {
                var category = new Category(0, categoryDto.Name);
                await _categoryService.Add(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, CategoryDto categoryDto)
        {
            try
            {
                var category = new Category(id, categoryDto.Name);
                await _categoryService.Add(category);
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
                var category = await _categoryService.GetSingleAsyncById(id);
                await _categoryService.Delete(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
