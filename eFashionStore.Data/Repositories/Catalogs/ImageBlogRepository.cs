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
    public interface IImageBlogRepository : IRepository<ImageBlog>
    {
    }
    public class ImageBlogRepository : RepositoryBase<ImageBlog>, IImageBlogRepository
    {
        public ImageBlogRepository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}