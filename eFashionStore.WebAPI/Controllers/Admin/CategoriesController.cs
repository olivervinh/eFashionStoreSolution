using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Service.Catalogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.WebAPI.Controllers.Admin
{
    [Route("api/admin/[controller]/{action}/{id?}")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public IEnumerable<Category> GetAll()
        {
            return _categoryService.GetAll();
        }
    }
}
