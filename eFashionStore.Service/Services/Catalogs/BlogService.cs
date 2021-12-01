using eFahionStore.Common.ViewModal.Catalog;
using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Service.Intrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.Catalogs
{
    public interface IBlogService : IBaseService<Blog>
    {
    }
    public class BlogService : BaseService<Blog>, IBlogService
    {
        public BlogService(IBaseRepository<Blog> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

    }
}
