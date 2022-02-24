using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Model.Models.Catalogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.Catalogs
{
    public interface IImageBlogRepository : IBaseRepository<ImageBlog>
    {
        public Task<IEnumerable<ImageBlog>> GetImageBlogsBaseFkBlogId(int FkBlogId);
    }
    public class ImageBlogRepository : BaseRepository<ImageBlog>, IImageBlogRepository
    {
        private readonly EFashionStoreDbContext _context;
        public ImageBlogRepository(EFashionStoreDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ImageBlog>> GetImageBlogsBaseFkBlogId(int FkBlogId)
        {
            return await _context.ImageBlogs.Where(x => x.FkBlogId == FkBlogId).ToArrayAsync();
        }
    }
}