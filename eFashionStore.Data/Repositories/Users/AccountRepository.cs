using AutoMapper;
using eFahionStore.Common.RequestViewModels.Users;
using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Model.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.Users
{
    public interface IAccountRepository
    {
        public Task<bool> RegisterNewCustomer(RegistrationViewModel registration);
        public Task<bool> EditAccount(UpdateUserProfile userProfile, string id);
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly EFashionStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public AccountRepository(EFashionStoreDbContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> RegisterNewCustomer(RegistrationViewModel registration)
        {
            var userExist = _userManager.FindByEmailAsync(registration.Email);
            if (userExist != null)
                return false;
            var userIdentity = _mapper.Map<AppUser>(registration);
            var result = await _userManager.CreateAsync(userIdentity, registration.Password);

            AppUser user = new AppUser();
            user = await _context.AppUsers.FirstOrDefaultAsync(s => s.Id == userIdentity.Id);

            _context.AppUsers.Update(user);
            if (!result.Succeeded)
                return false;
            return true;

        }

        public async Task<bool> EditAccount(UpdateUserProfile userProfile, string id)
        {
            var user = await _context.AppUsers.FindAsync(id);
            user.PhoneNumber = userProfile.PhoneNumber;
            user.Address = userProfile.Address;
            user.FirstName = userProfile.FirstName;
            user.LastName = userProfile.LastName;
            user.PasswordHash = userProfile.Password;
            _context.AppUsers.Update(user);
            return true;
        }
    }
}