using eFahionStore.Common.RequestViewModels.Users;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Users;
using eFashionStore.Model.Models.Users;
using eFashionStore.Service.Intrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Service.Services.Users
{
    public interface IAccountService : IBaseService<AppUser>
    {
        public Task<bool> RegisterNewCustomer(RegistrationViewModel registration);
        public Task<bool> EditAccount(UpdateUserProfile userProfile, string id);
    }
    public class AccountService : BaseService<AppUser>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IBaseRepository<AppUser> repository, IAccountRepository accountRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _accountRepository = accountRepository;
        }

        public async Task<bool> RegisterNewCustomer(RegistrationViewModel registration)
        {
            try
            {
                await _accountRepository.RegisterNewCustomer(registration);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public async Task<bool> EditAccount(UpdateUserProfile userProfile, string id)
        {
            try
            {
                await _accountRepository.EditAccount(userProfile, id);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
          
        }
    }
}
