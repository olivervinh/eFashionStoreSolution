﻿using eFahionStore.Common.RequestViewModels.Catalog;
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
        public async Task<IEnumerable<BlogAndImage>> GetBlogsPaginationList(int pageNumber, int pageSize)
        {
           return await _blogService.GetBlogsPaginationList(pageNumber, pageSize);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromForm] BlogDto blogDto)
        {
            try
            {
                var blog = new Blog(blogDto.Content, null, null, blogDto.Content,null);              
                await _blogService.Add(blog);
                int index = 0;
                foreach (var formFile in blogDto.ImageBlogs)
                {
                    if (formFile.Length > 0 && formFile.Length < 2048)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Pro", "blog_" + blog.Id);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        if (index == 0)
                        {
                            var imageBlog = new ImageBlog("blog_" + blog.Id, true, blog.Id, null);                         
                            await _imageBlogService.Add(imageBlog);
                        }
                        else
                        {
                            var imageBlog = new ImageBlog("blog_" + blog.Id, false, blog.Id, null);
                            await _imageBlogService.Add(imageBlog);
                        }

                    }
                    index++;
                }
                return Ok();
            }
            catch(Exception ex)
            {
              return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id,[FromForm] BlogDto blogDto)
        {
            try
            {
                // delete images base blog updating
                var imageBlogBaseBlogList = await _imageBlogService.GetImageBlogsBaseFkBlogId(id);
                foreach(var item in imageBlogBaseBlogList)
                {
                    System.IO.File.Delete(Path.Combine("wwwroot/Images/ImagesBlog", item.ImageName));
                }
                await _imageBlogService.DeleteRange(imageBlogBaseBlogList);
                var blog = new Blog(blogDto.Content, null, null, blogDto.Content, null);
                await _blogService.Add(blog);
                int index = 0;
                foreach (var formFile in blogDto.ImageBlogs)
                {
                    if (formFile.Length > 0 && formFile.Length < 2048)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Pro", "blog_" + blog.Id);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        if (index == 0)
                        {
                            var imageBlog = new ImageBlog("blog_" + blog.Id, true, blog.Id, null);
                            await _imageBlogService.Add(imageBlog);
                        }
                        else
                        {
                            var imageBlog = new ImageBlog("blog_" + blog.Id, false, blog.Id, null);
                            await _imageBlogService.Add(imageBlog);
                        }

                    }
                    index++;
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }
    }
}
