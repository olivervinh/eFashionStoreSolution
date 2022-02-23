using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Users;
using eFashionStore.Model.Models.Users;
using eFashionStore.Service.Intrastructure;


namespace eFashionStore.Service.Services.Catalogs
{
    public interface IAppUserService : IBaseService<AppUser>
    {

    }
    public class AppUserService : BaseService<AppUser>, IAppUserService
    {
        private IAppUserRepository _appUserRepository;
        public AppUserService(IBaseRepository<AppUser> repository, IAppUserRepository appUserRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _appUserRepository = appUserRepository;
        }

    }
}
