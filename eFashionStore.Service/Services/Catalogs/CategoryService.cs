using eFahionStore.Common.Helpers;
using eFahionStore.Common.RequestViewModels.Catalog;
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
        IQueryable<Category> GetCategoriesCondition(string Search);
        Task<IEnumerable<Category>> GetCategoriesSearchSortOrderPagination(string searchString, int? pageNumber, string sortOrder);
        Task<bool> CreateNewCategory(CategoryDto categoryDto);
        Task<bool> UpdateCategory(CategoryDto categoryDto);
        Task<bool> DeleleCategory(CategoryDto categoryDto);
    }
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(IBaseRepository<Category> repository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> CreateNewCategory(CategoryDto categoryDto)
        {
            if (!ValidateHelper.ValidateWrongStringName(categoryDto.Name))
            {
                var category = new Category(categoryDto.Id, categoryDto.Name);
                await this.Add(category);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleleCategory(CategoryDto categoryDto)
        {
            if (categoryDto != null && categoryDto.Id != 0)
            {
                try
                {
                    var category = new Category(categoryDto.Id, "");
                    await this.Delete(category);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public IQueryable<Category> GetCategoriesCondition(string Search)
        {
            if (int.TryParse(Search, out int id))
                return _categoryRepository.GetListCondition(x => x.Name.Contains(Search) || x.Id == id);
            return _categoryRepository.GetListCondition(x => x.Name.Contains(Search));
        }

        public async Task<IEnumerable<Category>> GetCategoriesSearchSortOrderPagination(string searchString, int? pageNumber, string sortOrder)
        {
            var condition = this.GetQueryable();
            if (searchString != null)
                condition = this.GetCategoriesCondition(searchString);
            switch (sortOrder)
            {
                case "id_desc":
                    condition = condition.OrderByDescending(s => s.Id);
                    break;
                case "name":
                    condition = condition.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    condition = condition.OrderByDescending(s => s.Name);
                    break;
                default:
                    condition = condition.OrderBy(s => s.Id);
                    break;
            }

            return await this.GetPaginationListAsync(condition, pageNumber ?? 1, 5);
        }

        public async Task<bool> UpdateCategory(CategoryDto categoryDto)
        {
            if (!ValidateHelper.ValidateWrongStringName(categoryDto.Name))
            {
                var category = new Category(categoryDto.Id, categoryDto.Name);
                await this.Update(category);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
