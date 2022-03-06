using eFahionStore.Common.RequestViewModels.Catalog;
using eFashionStore.Service.Services.Catalogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizesController : Controller
    {
        private ISizeService _sizeService;
        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }
        // GET: SizesController
        [HttpGet]
        public async Task<IActionResult> Index(string searchString, int? pageNumber, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            return View(await _sizeService.GetSizesSearchSortOrderPagination(searchString, pageNumber, sortOrder));
        }

        // GET: SizesController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _sizeService.GetSingleAsyncById(id));
        }
        // POST: SizesController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SizeDto sizeDto)
        {
            var result = await _sizeService.CreateNewSize(sizeDto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] SizeDto sizeDto)
        {

            var result = await _sizeService.UpdateSize(sizeDto);
            if (result)
                return Ok();
            return BadRequest();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] SizeDto sizeDto)
        {
            var result = await _sizeService.DeleleSize(sizeDto);
            if (result)
                return Ok();
            return BadRequest();
        }

    }
}
