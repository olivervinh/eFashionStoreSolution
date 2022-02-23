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

    }
    public class SizeService : BaseService<Size>, ISizeService
    {
        private ISizeRepository _sizeRepository;
        public SizeService(IBaseRepository<Size> repository, ISizeRepository sizeRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _sizeRepository = sizeRepository;
        }

    }
}
