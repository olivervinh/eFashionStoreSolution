using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.WareHouses;
using eFashionStore.Model.Models.WareHouses;
using eFashionStore.Service.Intrastructure;


namespace eFashionStore.Service.Services.WareHouses
{
    public interface ISupplierService : IBaseService<Supplier>
    {

    }
    public class SupplierService : BaseService<Supplier>, ISupplierService
    {
        private ISupplierRepository _supplierRepository;
        public SupplierService(IBaseRepository<Supplier> repository, ISupplierRepository supplierRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _supplierRepository = supplierRepository;
        }

    }
}
