using eFahionStore.Common.RequestViewModels.Catalog;
using eFashionStore.Model.Models.Catalogs;
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
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: CategorysController
        [HttpGet]
        public async Task<IActionResult> Index(string searchString, int? pageNumber, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            return View(await _categoryService.GetCategoriesSearchSortOrderPagination(searchString, pageNumber, sortOrder));
        }

        // GET: CategorysController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _categoryService.GetSingleAsyncById(id));
        }
        // POST: CategorysController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.CreateNewCategory(categoryDto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CategoryDto categoryDto)
        {

            var result = await _categoryService.UpdateCategory(categoryDto);
            if (result)
                return Ok();
            return BadRequest();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.DeleleCategory(categoryDto);
            if (result)
                return Ok();
            return BadRequest();
        }

    }
}
