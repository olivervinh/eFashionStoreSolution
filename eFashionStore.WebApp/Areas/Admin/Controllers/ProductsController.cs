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
    public class ProductsController : Controller
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: ProductsController
        [HttpGet]
        public async Task<IActionResult> Index(string searchString, int? pageNumber, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["SellPriceSortParm"] = sortOrder == "sellPrice" ? "sellPrice_desc" : "sellPrice";
            ViewData["ImportPriceSortParm"] = sortOrder == "importPrice" ? "importPrice_desc" : "importPrice";
            ViewData["StatusProductSortParm"] = sortOrder == "statusProduct" ? "statusProduct_desc" : "statusProduct";
            ViewData["IsActiveSortParm"] = sortOrder == "isActive" ? "isActive_desc" : "isActive";
            ViewData["GenderSortParm"] = sortOrder == "gender" ? "gender_desc" : "gender";
            ViewData["BrandSortParm"] = sortOrder == "brand" ? "brand_desc" : "brand";
            ViewData["CategorySortParm"] = sortOrder == "category" ? "category_desc" : "category";
            ViewData["SupplierSortParm"] = sortOrder == "supplier" ? "supplier_desc" : "supplier";

            return View(await _productService.GetProductsSearchSortOrderPagination(searchString, pageNumber, sortOrder));
        }

        // GET: BrandsController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _productService.GetSingleAsyncById(id));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // POST: BrandsController/Create

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            var result = await _productService.CreateVariantProductBaseProduct(productDto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ProductDto productDto)
        {

            var result = await _productService.UpdateVariantProductBaseProduct(productDto.Id,productDto);
            if (result)
                return Ok();
            return BadRequest();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteImageBaseProduct(id);
            if (result)
                return Ok();
            return BadRequest();
        }

    }
}
