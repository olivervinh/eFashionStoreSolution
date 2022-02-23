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

    }
    public class ColorService : BaseService<Color>, IColorService
    {
        private IColorRepository _colorRepository;
        public ColorService(IBaseRepository<Color> repository, IColorRepository colorRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _colorRepository = colorRepository;
        }

    }
}
