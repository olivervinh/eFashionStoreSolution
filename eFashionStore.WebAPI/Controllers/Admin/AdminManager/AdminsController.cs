using eFahionStore.Common.RequestViewModels.Users;
using eFashionStore.Service.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.WebAPI.Controllers.Admin.UserManager
{
    [Route("api/admin/admin/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAuthenticationService _authenticationService;
        public AdminsController(IAccountService accountService, IAuthenticationService authenticationService)
        {
            _accountService = accountService;
            _authenticationService = authenticationService;
        }
        public async Task<IActionResult> AdminLoginReturnToken([FromBody] CredentialsViewModel credential)
        {
            string Rolelogin = "Admin";
            var response = await _authenticationService.LoginReturnToken(credential, Rolelogin);
            if (response==null)
            {
                return BadRequest(ModelState);
            }
          
            return Ok(response);
        }
     
        public async Task<IActionResult> EditAccount(UpdateUserProfile userProfile, string id)
        {
            var response = await _accountService.EditAccount(userProfile,id);
            if (response)
                return Ok();
            return BadRequest();
        }
    }

}
