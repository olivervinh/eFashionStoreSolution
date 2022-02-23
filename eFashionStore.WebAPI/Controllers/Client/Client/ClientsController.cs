using eFahionStore.Common.RequestViewModels.Users;
using eFashionStore.Service.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.WebAPI.Controllers.Client.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAuthenticationService _authenticationService;
        public ClientsController(IAccountService accountService, IAuthenticationService authenticationService)
        {
            _accountService = accountService;
            _authenticationService = authenticationService;
        }
        public async Task<IActionResult> RegisterNewCustomer([FromForm] RegistrationViewModel registration)
        {
            var response = await _accountService.RegisterNewCustomer(registration);
            if (response)
                return Ok();
            return BadRequest();
        }
        public async Task<IActionResult> ClientLoginReturnToken([FromBody] CredentialsViewModel credentials)
        {
            string Rolelogin = "Client";
            var response = await _authenticationService.LoginReturnToken(credentials,Rolelogin);
            if (response == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(response);
        }
    }
}
