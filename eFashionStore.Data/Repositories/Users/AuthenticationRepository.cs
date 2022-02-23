using AutoMapper;
using eFahionStore.Common.RequestViewModels.Users;
using eFashionStore.Data.EF;
using eFashionStore.Model.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.Users
{
   
    public interface IAuthenticationRepository
    {

        public Task<OkObjectResult> LoginReturnToken(CredentialsViewModel credential, string Rolelogin); 
    }
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly EFashionStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly JsonSerializerSettings _serializerSettings;
        public AuthenticationRepository(EFashionStoreDbContext context, UserManager<AppUser> userManager, IMapper mapper, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
            _mapper = mapper;
            _context = context;
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }
        public async Task<OkObjectResult> LoginReturnToken(CredentialsViewModel credential, string Rolelogin)
        {
            string id ="";
            if (credential != null)
            {
                var userToVerify = await _userManager.FindByNameAsync(credential.UserName);
                await _userManager.CheckPasswordAsync(userToVerify, credential.Password);
                var identity = await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(credential.UserName, userToVerify.Id));
                if (identity != null)
                {
                    var response = new
                    {
                        id = identity.Claims.Single(c => c.Type == "id").Value,
                        role = _context.AppUsers.FirstOrDefault(s => s.Id == id ).Role,
                        image = _context.AppUsers.FirstOrDefault(s => s.Id == id).ImagePath,
                        email = _context.AppUsers.FirstOrDefault(s => s.Id == id).Email,
                        auth_token = await _jwtFactory.GenerateEncodedToken(credential.UserName, identity),
                        expires_in = (int)_jwtOptions.ValidFor.TotalSeconds
                    };
                    if(response.role != Rolelogin)
                    {
                        return null;
                    }
                    var json = JsonConvert.SerializeObject(response, _serializerSettings);
                    return new OkObjectResult(json);
                }
            }
            return null;
        }
    }
}