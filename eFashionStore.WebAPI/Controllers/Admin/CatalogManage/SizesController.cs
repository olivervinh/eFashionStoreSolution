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
    public class SizesController : ControllerBase
    { 
        private ISizeService _sizeService;
        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Size>> GetAllSizes()
        {
            return await _sizeService.GetAllAsync();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSize([FromForm] SizeDto sizeDto)
        {
            try
            {
                var size = new Size(0, sizeDto.Name,sizeDto.FkCategoryId,null, null);
                await _sizeService.Add(size);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSize(int id, [FromForm] SizeDto sizeDto)
        {
            try
            {
                var size = new Size(id, sizeDto.Name, sizeDto.FkCategoryId, null, null);
                await _sizeService.Add(size);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSize(int id)
        {
            try
            {
                var size = await _sizeService.GetSingleAsyncById(id);
                await _sizeService.Delete(size);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}