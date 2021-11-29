using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Users;
using eFashionStore.Model.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Users
{
    public interface IAppUserService
    {
        AppUser Add(AppUser AppUser);

        void Update(AppUser AppUser);

        AppUser Delete(int id);

        IEnumerable<AppUser> GetAll();

        IEnumerable<AppUser> GetAll(string keyword);

        IEnumerable<AppUser> GetAllByParentId(int parentId);

        AppUser GetById(int id);

        Task<bool> SaveAsync();
    }
    public class AppUserService : IAppUserService
    {
        private IAppUserRepository _appUserRepository;
        private IUnitOfWork _unitOfWork;
        public AppUserService(IAppUserRepository appUserRepository, IUnitOfWork unitOfWork)
        {
            _appUserRepository = appUserRepository;
            _unitOfWork = unitOfWork;
        }
        public AppUser Add(AppUser AppUser)
        {
            return _appUserRepository.Add(AppUser);
        }

        public AppUser Delete(int id)
        {
            return _appUserRepository.Delete(id);
        }

        public IEnumerable<AppUser> GetAll()
        {
            return _appUserRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<AppUser> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<AppUser> GetAllByParentId(int parentId)
        {
            return null;
        }

        public AppUser GetById(int id)
        {
            return _appUserRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(AppUser AppUser)
        {
            _appUserRepository.Update(AppUser);
        }
    }
}
