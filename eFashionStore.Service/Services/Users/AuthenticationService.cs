using eFahionStore.Common.RequestViewModels.Users;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Users;
using eFashionStore.Model.Models.Users;
using eFashionStore.Service.Intrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Service.Services.Users
{
    public interface IAuthenticationService : IBaseService<AppUser>
    {
        public Task<OkObjectResult> LoginReturnToken(CredentialsViewModel credential, string Rolelogin);
    }
    public class AuthenticationService : BaseService<AppUser>, IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationService(IAuthenticationRepository authenticationRepository, IBaseRepository<AppUser> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<OkObjectResult> LoginReturnToken(CredentialsViewModel credential, string Rolelogin)
        {
            var token = await _authenticationRepository.LoginReturnToken(credential, Rolelogin);
            return token;

        }
    }
}
