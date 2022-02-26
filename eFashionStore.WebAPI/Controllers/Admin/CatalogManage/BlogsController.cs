using eFahionStore.Common.RequestViewModels.Catalog;
using eFahionStore.Common.ViewModal.Catalog;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Service.Services.Catalogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.WebAPI.Controllers.Admin.CatalogManage
{
    [Route("api/admin/catalog/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private IBlogService _blogService;
        private IImageBlogService _imageBlogService;
        public BlogsController(IBlogService blogService, IImageBlogService imageBlogService)
        {
            _blogService = blogService;
            _imageBlogService = imageBlogService;
        }
        [HttpGet("GetPaginationList")]
        public async Task<IEnumerable<BlogJoinImage>> GetCustomBlogsPaginationListAsync(int pageNumber, int pageSize)
        {
           return await _blogService.GetCustomBlogsPaginationListAsync(pageNumber, pageSize);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromForm] BlogDto blogDto)
        {
            var result = await _blogService.CreateImageBaseBlog(blogDto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id,[FromForm] BlogDto blogDto)
        {
            var result = await _blogService.UpdateImageBaseBlog(id,blogDto);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var result = await _blogService.DeleteImageBaseBlog(id);
            if (result)
                return Ok();
            return BadRequest();

        }
    }
}
