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
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Color>> GetAllColors()
        {
            return await _colorService.GetAllAsync();
        }
        [HttpPost]
        public async Task<IActionResult> CreateColor([FromForm] ColorDto colorDto)
        {
            try
            {
                var color = new Color(0, colorDto.Name,colorDto.FkCategoryId,null, null);
                await _colorService.Add(color);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColor(int id, [FromForm] ColorDto colorDto)
        {
            try
            {
                var color = new Color(id, colorDto.Name, colorDto.FkCategoryId, null, null);
                await _colorService.Update(color);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            try
            {
                var color = await _colorService.GetSingleAsyncById(id);
                await _colorService.Delete(color);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
