using eFahionStore.Common.ViewModal.Catalog;
using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Service.Intrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eFashionStore.Service.Services.Catalogs
{
    public interface IImageBlogService : IBaseService<ImageBlog>
    {
        public Task<IEnumerable<ImageBlog>> GetImageBlogsBaseFkBlogId(int FkBlogId);
    }
    public class ImageBlogService : BaseService<ImageBlog>, IImageBlogService
    {
        private IImageBlogRepository _imageBlogRepository;
        public ImageBlogService(IBaseRepository<ImageBlog> repository, IImageBlogRepository imageBlogRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _imageBlogRepository = imageBlogRepository;
        }

        public async Task<IEnumerable<ImageBlog>> GetImageBlogsBaseFkBlogId(int FkBlogId)
        {
            return await _imageBlogRepository.GetImageBlogsBaseFkBlogId(FkBlogId);
        }
    }
}
