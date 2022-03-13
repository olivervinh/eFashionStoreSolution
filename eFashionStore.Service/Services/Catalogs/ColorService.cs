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
    public interface IColorService : IBaseService<Color>
    {
        IQueryable<Color> GetColorsCondition(string Search);
        Task<IEnumerable<Color>> GetColorsSearchSortOrderPagination(string searchString, int? pageNumber, string sortOrder);
        Task<bool> CreateNewColor(ColorDto colorDto);
        Task<bool> UpdateColor(ColorDto colorDto);
        Task<bool> DeleleColor(ColorDto colorDto);
    }
    public class ColorService : BaseService<Color>, IColorService
    {
        private IColorRepository _colorRepository;
        public ColorService(IBaseRepository<Color> repository, IColorRepository colorRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _colorRepository = colorRepository;
        }

        public async Task<bool> CreateNewColor(ColorDto colorDto)
        {
            if (!ValidateHelper.ValidateWrongStringName(colorDto.Name))
            {
                var color = new Color(colorDto.Id, colorDto.Name,colorDto.FkCategoryId, null,null);
                await this.Add(color);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleleColor(ColorDto colorDto)
        {
            if (colorDto != null && colorDto.Id != 0)
            {
                try
                {
                    var color = new Color(colorDto.Id, colorDto.Name, null, null, null);
                    await this.Delete(color);
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

        public IQueryable<Color> GetColorsCondition(string Search)
        {
            if (int.TryParse(Search, out int id))
                return _colorRepository.GetListCondition(x => x.Name.Contains(Search) || x.Id == id);
            return _colorRepository.GetListCondition(x => x.Name.Contains(Search));
        }

        public async Task<IEnumerable<Color>> GetColorsSearchSortOrderPagination(string searchString, int? pageNumber, string sortOrder)
        {
            var condition = this.GetQueryable();
            if (searchString != null)
                condition = this.GetColorsCondition(searchString);
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

        public async Task<bool> UpdateColor(ColorDto colorDto)
        {
            if (!ValidateHelper.ValidateWrongStringName(colorDto.Name))
            {
                var color = new Color(colorDto.Id, colorDto.Name, colorDto.FkCategoryId, null, null);
                await this.Update(color);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
