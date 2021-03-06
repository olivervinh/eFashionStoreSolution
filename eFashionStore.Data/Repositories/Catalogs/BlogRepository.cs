using eFahionStore.Common.Helpers;
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
        public Task<IEnumerable<BlogJoinImage>> GetCustomBlogsPaginationListAsync(int pageNumber, int pageSize);
       
    }
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        private readonly EFashionStoreDbContext _context;
        public BlogRepository(EFashionStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogJoinImage>> GetCustomBlogsPaginationListAsync(int pageNumber, int pageSize)
        {
            var blogsList =  (from b in _context.Blogs
                                 join ib in _context.ImageBlogs.Where(x => x.IsThumbnail == true)
                                 on b.Id equals ib.FkBlogId
                                 select new BlogJoinImage()
                                 {
                                     Id = b.Id,
                                     Title = b.Title,
                                     Content = b.Content,
                                     Image = ib.ImageName,
                                     UserFullName = "Admin",
                                 });
            var blogsPaginationList = PagedPaginationHelper<BlogJoinImage>.CreateAsync(blogsList, pageNumber, pageSize);
            return await blogsPaginationList;
        }

       
    }
}
