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
    public class ColorController : Controller
    {
        private IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }
        // GET: ColorsController
        [HttpGet]
        public async Task<IActionResult> Index(string searchString, int? pageNumber, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            return View(await _colorService.GetColorsSearchSortOrderPagination(searchString, pageNumber, sortOrder));
        }

        // GET: ColorsController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _colorService.GetSingleAsyncById(id));
        }
        // POST: ColorsController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ColorDto colorDto)
        {
            var result = await _colorService.CreateNewColor(colorDto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ColorDto colorDto)
        {

            var result = await _colorService.UpdateColor(colorDto);
            if (result)
                return Ok();
            return BadRequest();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ColorDto colorDto)
        {
            var result = await _colorService.DeleleColor(colorDto);
            if (result)
                return Ok();
            return BadRequest();
        }

    }
}
