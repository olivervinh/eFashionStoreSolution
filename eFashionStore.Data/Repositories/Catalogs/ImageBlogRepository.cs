using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Model.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.Catalogs
{
    public interface IImageBlogRepository : IBaseRepository<ImageBlog>
    {
    }
    public class ImageBlogRepository : BaseRepository<ImageBlog>, IImageBlogRepository
    {
        public ImageBlogRepository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}