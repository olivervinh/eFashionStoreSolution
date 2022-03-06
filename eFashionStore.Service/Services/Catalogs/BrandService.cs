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
    public interface IBrandService : IBaseService<Brand>
    {
        IQueryable<Brand> GetBrandsCondition(string Search);
        Task<IEnumerable<Brand>> GetBrandsSearchSortOrderPagination(string searchString, int? pageNumber,string sortOrder);
        Task<bool> CreateNewBrand(BrandDto brandDto);
        Task<bool> UpdateBrand(BrandDto brandDto);
        Task<bool> DeleleBrand(BrandDto brandDto);
    }
    public class BrandService : BaseService<Brand>, IBrandService
    {
        private IBrandRepository _brandRepository;
        public BrandService(IBaseRepository<Brand> repository, IBrandRepository brandRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _brandRepository = brandRepository;
        }

        public async Task<bool> CreateNewBrand(BrandDto brandDto)
        {
            if (!ValidateHelper.ValidateWrongStringName(brandDto.Name))
            {
                var brand = new Brand(brandDto.Id, brandDto.Name);
                await this.Add(brand);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleleBrand(BrandDto brandDto)
        {
            if (brandDto!=null&&brandDto.Id != 0)
            {
                try
                {
                    var brand = new Brand(brandDto.Id, "");
                    await this.Delete(brand);
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

        public IQueryable<Brand> GetBrandsCondition(string Search)
        {    
            if(int.TryParse(Search, out int id))
                return _brandRepository.GetListCondition(x => x.Name.Contains(Search)||x.Id==id);
            return _brandRepository.GetListCondition(x => x.Name.Contains(Search));
        }

        public async Task<IEnumerable<Brand>> GetBrandsSearchSortOrderPagination(string searchString, int? pageNumber, string sortOrder)
        {
            var condition = this.GetQueryable();
            if (searchString != null)
                condition = this.GetBrandsCondition(searchString);
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

        public async Task<bool> UpdateBrand(BrandDto brandDto)
        {
            if (!ValidateHelper.ValidateWrongStringName(brandDto.Name))
            {
                var brand = new Brand(brandDto.Id, brandDto.Name);
                await this.Update(brand);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
