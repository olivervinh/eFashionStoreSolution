using eFahionStore.Common.ViewModal.Catalog;
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
    public interface IBlogRepository : IBaseRepository<Blog>
    {
        Task<IEnumerable<BlogAndImage>> GetBlogAndImagesList();
    }
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        private readonly EFashionStoreDbContext _context;
        public BlogRepository(EFashionStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogAndImage>> GetBlogAndImagesList()
        {
            var blogs = _context.Blogs.Select(b => new BlogAndImage()
            {

                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                image = _context.ImageBlogs.Where(s => s.FkBlogId == b.Id).Select(s => s.ImageName).FirstOrDefault(),
                nameUser = _context.AppUsers.Where(s => s.Id == b.FkAppUserId).Select(s => s.FirstName + " " + s.LastName).FirstOrDefault(),

            });
            return await blogs.ToListAsync();
        }
    }
}
