using eFahionStore.Common.ViewModal.Catalog;
using eFashionStore.Data.Repositories.Catalogs;
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
    public class BlogsController : ControllerBase
    {
        private IBlogService _blogService;
        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet("GetBlogAndImagesList")]
        public async Task<IEnumerable<BlogAndImage>> GetBlogAndImagesList()
        {
            return await _blogService.GetBlogAndImagesList();
        }
    }
}
