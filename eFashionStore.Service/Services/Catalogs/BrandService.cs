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
       
    }
    public class BrandService : BaseService<Brand>, IBrandService
    {
        private IBrandRepository _brandRepository;
        public BrandService(IBaseRepository<Brand> repository, IBrandRepository brandRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _brandRepository = brandRepository;
        }
       
    }
}
