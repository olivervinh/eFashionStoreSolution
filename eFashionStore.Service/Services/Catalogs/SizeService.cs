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
    public interface ISizeService : IBaseService<Size>
    {
        IQueryable<Size> GetSizesCondition(string Search);
        Task<IEnumerable<Size>> GetSizesSearchSortOrderPagination(string searchString, int? pageNumber, string sortOrder);
        Task<bool> CreateNewSize(SizeDto sizeDto);
        Task<bool> UpdateSize(SizeDto sizeDto);
        Task<bool> DeleleSize(SizeDto sizeDto);
    }
    public class SizeService : BaseService<Size>, ISizeService
    {
        private ISizeRepository _sizeRepository;
        public SizeService(IBaseRepository<Size> repository, ISizeRepository sizeRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<bool> CreateNewSize(SizeDto sizeDto)
        {
            if (!ValidateHelper.ValidateWrongStringName(sizeDto.Name))
            {
                var size = new Size(sizeDto.Id, sizeDto.Name,null,null,null);
                await this.Add(size);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleleSize(SizeDto sizeDto)
        {
            if (sizeDto != null && sizeDto.Id != 0)
            {
                try
                {
                    var size = new Size(sizeDto.Id, "",null,null,null);
                    await this.Delete(size);
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

        public IQueryable<Size> GetSizesCondition(string Search)
        {
            if (int.TryParse(Search, out int id))
                return _sizeRepository.GetListCondition(x => x.Name.Contains(Search) || x.Id == id);
            return _sizeRepository.GetListCondition(x => x.Name.Contains(Search));
        }

        public async Task<IEnumerable<Size>> GetSizesSearchSortOrderPagination(string searchString, int? pageNumber, string sortOrder)
        {
            var condition = this.GetQueryable();
            if (searchString != null)
                condition = this.GetSizesCondition(searchString);
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

        public async Task<bool> UpdateSize(SizeDto sizeDto)
        {
            if (!ValidateHelper.ValidateWrongStringName(sizeDto.Name))
            {
                var size = new Size(sizeDto.Id, sizeDto.Name, null, null, null);
                await this.Update(size);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
