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
    public interface ICategoryService : IBaseService<Category>
    {

    }
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(IBaseRepository<Category> repository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
        }

    }
}
