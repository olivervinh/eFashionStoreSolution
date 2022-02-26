using eFahionStore.Common.RequestViewModels.Catalog;
using eFahionStore.Common.ViewModal.Catalog;
using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Service.Intrastructure;
using eFashionStore.Service.Services.Catalogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.Catalogs
{
    public interface IBlogService : IBaseService<Blog>
    {
        public Task<IEnumerable<BlogJoinImage>> GetCustomBlogsPaginationListAsync(int pageNumber, int pageSize);
        public Task<bool> CreateImageBaseBlog(BlogDto blogDto);
        public Task<bool> UpdateImageBaseBlog(int id,BlogDto blogDto);
        public Task<bool> DeleteImageBaseBlog(int id);
    }
    public class BlogService : BaseService<Blog>, IBlogService
    {
        private ImageBlogService _imageBlogService;
        private IBlogRepository _blogRepository;
        public BlogService(IBaseRepository<Blog> repository, ImageBlogService imageBlogService, IBlogRepository blogRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _blogRepository = blogRepository;
            _imageBlogService = imageBlogService;
        }
        public async Task<IEnumerable<BlogJoinImage>> GetCustomBlogsPaginationListAsync(int pageNumber, int pageSize)
        {
            return await _blogRepository.GetCustomBlogsPaginationListAsync(pageNumber, pageSize);
        }


        public async Task<bool> CreateImageBaseBlog(BlogDto blogDto)
        {
            try
            {
                var blog = new Blog(0, blogDto.Content, null, null, blogDto.Content, null);
                await this.Add(blog);
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
                            var imageBlog = new ImageBlog(0, "blog_" + blog.Id, true, blog.Id, null);
                            await _imageBlogService.Add(imageBlog);
                        }
                        else
                        {
                            var imageBlog = new ImageBlog(0, "blog_" + blog.Id, false, blog.Id, null);
                            await _imageBlogService.Add(imageBlog);
                        }

                    }
                    index++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateImageBaseBlog(int id, BlogDto blogDto)
        {
            try
            {
                var imageBlogBaseBlogList = await _imageBlogService.GetImageBlogsBaseFkBlogId(id);
                foreach (var item in imageBlogBaseBlogList)
                {
                    System.IO.File.Delete(Path.Combine("wwwroot/Images/ImagesBlog", item.ImageName));
                }
                await _imageBlogService.DeleteRange(imageBlogBaseBlogList);
                var blog = new Blog(id, blogDto.Content, null, null, blogDto.Content, null);
                await this.Update(blog);
                int index = 0;
                foreach (var formFile in blogDto.ImageBlogs)
                {
                    if (formFile.Length > 0 && formFile.Length < 2048)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/ImagesBlog", "blog_" + blog.Id);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        if (index == 0)
                        {
                            var imageBlog = new ImageBlog(0, "blog_" + blog.Id, true, blog.Id, null);
                            await _imageBlogService.Add(imageBlog);
                        }
                        else
                        {
                            var imageBlog = new ImageBlog(0, "blog_" + blog.Id, false, blog.Id, null);
                            await _imageBlogService.Add(imageBlog);
                        }

                    }
                    index++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteImageBaseBlog(int id)
        {
            try
            {
                var imageBlogBaseBlogList = await _imageBlogService.GetImageBlogsBaseFkBlogId(id);
                foreach (var item in imageBlogBaseBlogList)
                {
                    System.IO.File.Delete(Path.Combine("wwwroot/Images/ImagesBlog", item.ImageName));
                }
                var result = Task.Run(async () => await _imageBlogService.DeleteRange(imageBlogBaseBlogList)).Result;
                var blog = await this.GetSingleAsyncById(id);
                if (result)
                    await this.Delete(blog);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
    }
}
