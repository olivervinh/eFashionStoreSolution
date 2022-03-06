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
    public class BrandsController : Controller
    {
        private IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        // GET: BrandsController
        [HttpGet]
        public async Task<IActionResult> Index(string searchString, int? pageNumber, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString; 
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            return View(await _brandService.GetBrandsSearchSortOrderPagination(searchString, pageNumber, sortOrder));
        }

        // GET: BrandsController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {          
            return Ok(await _brandService.GetSingleAsyncById(id));
        }
        // POST: BrandsController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]BrandDto brandDto)
        {
            var result = await _brandService.CreateNewBrand(brandDto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] BrandDto brandDto)
        {
            
            var result = await _brandService.UpdateBrand(brandDto);
            if (result)
                return Ok();
            return BadRequest();
        }

       
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] BrandDto brandDto)
        {
            var result = await _brandService.DeleleBrand(brandDto);
            if (result)
                return Ok();
            return BadRequest();       
        }

    }
}
