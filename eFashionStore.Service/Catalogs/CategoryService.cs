using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Catalogs
{
    public interface ICategoryService
    {
        Category Add(Category Category);

        void Update(Category Category);

        Category Delete(int id);

        IEnumerable<Category> GetAll();

        IEnumerable<Category> GetAll(string keyword);

        IEnumerable<Category> GetAllByParentId(int parentId);

        Category GetById(int id);

        Task<bool> SaveAsync();
    }
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
        }
        public Category Add(Category Category)
        {
            return _categoryRepository.Add(Category);
        }

        public Category Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<Category> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<Category> GetAllByParentId(int parentId)
        {
            return _categoryRepository.GetMulti(x =>x.Id == parentId);
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(Category Category)
        {
            _categoryRepository.Update(Category);
        }
    }
}
